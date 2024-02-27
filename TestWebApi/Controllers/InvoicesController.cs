using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(InvoicesController));

        private string ConnectionString { get; set; }

        public InvoicesController()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }


        /// <summary>
        /// Task: Recalculate and save invoice line numbers starting from 1 rather than 0.
        /// </summary>
        [HttpPost]
        public async Task<DbInvoice> AddInvoiceLine(string id, InvoiceLineData line)
        {
            DbInvoice inv = new DbInvoice();

            if (line != null)
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    Logger.Info("Start processing new invoice line");

                    var connection = new SqlConnection(ConnectionString);
                    await connection.OpenAsync();

                    // Get invoice lines from sql server instance.

                    Logger.Info("Get invoice from sql server instance");
                    var invoiceNumber = Convert.ToInt32(id);

                    var i = await DbInvoiceReader.GetInvoice(invoiceNumber, connection);

                    if (i != null)
                    {
                        var insertCmdStr = $"INSERT INTO [dbo].[InvoiceLines] ([InvoiceId], [InvoiceNumber], [ProductId], [ProductName], [ProductSKU], [Quantity], [Subtotal], [LineNumber]) VALUES ({i.Id}, {invoiceNumber}, {line.ProductId}, '{line.ProductName}', '{line.ProductSKU}', {line.Quantity}, 0, 0)";
                         
                        var insertCmd = new SqlCommand(insertCmdStr, connection);
                        await insertCmd.ExecuteNonQueryAsync();


                        var cmdTxt = $"SELECT * FROM [dbo].[InvoiceLines] WHERE [InvoiceNumber] = {id}";

                        // Get invoice lines from sql server instance.
                        Logger.Info("Get invoice lines from sql server instance");

                        var svc = new InvoiceLinesService(connection);
                        var lines = await svc.GetInvoiceLines(cmdTxt);
                        if (lines == null || lines.Count == 0)
                        {
                            throw new Exception($"INvoice {id} does not have invoice lines!");
                        }

                        if (lines.Count == 1)
                        {
                            i.Lines = new List<DbInvoiceLine>()
                            {
                                lines[0]
                            };

                            if (i.Updateable == true)
                            {
                                var proMgr = new ProductManager(connection);
                                var singleLine = i.Lines[0];

                                var pros = new List<SqlProduct>();

                                var sqlproCmd = $"SELECT * FROM [dbo].[Products] WHERE [SKU] = '{singleLine.SKU}'";
                                var prod = await proMgr.GetProduct(sqlproCmd, connection);
                                if (prod != null)
                                    pros.Add(prod);

                                i.Lines[0].LineNumber = 0;
                                i.Lines[0].Subtotal = CalcSubtotal(singleLine, pros);

                                var updateCmdStr = $"UPDATE [dbo].[InvoiceLines] SET [LineNumber] = {singleLine.LineNumber}, [Subtotal] = {singleLine.Subtotal} WHERE [Id] = {singleLine.InvoiceLineId}";

                                var cmd = new SqlCommand(updateCmdStr, connection);
                                await cmd.ExecuteNonQueryAsync();

                                throw new Exception("some error occurred.");
                            }
                        }
                        else
                        {
                            i.Lines = new List<DbInvoiceLine>();
                            foreach (var l in lines)
                            {
                                i.Lines.Add(l);
                            }

                            if (!i.Updateable == false)
                            {
                                var proMgr = new ProductManager(connection);

                                var pros = new List<SqlProduct>();

                                foreach (var x in i.Lines)
                                {
                                    string sqlproCmd = $"SELECT * FROM [dbo].[Products] WHERE [SKU] = '{x.SKU}'";
                                    var pro = await proMgr.GetProduct(sqlproCmd, connection);

                                    if (pro != null)
                                    {
                                        pros.Add(pro);
                                    }
                                }

                                
                                // TODO: Make line number to be 1 based. Currently 0-based.
                                var lineNumber = 0;
                                foreach (var lx in i.Lines)
                                {
                                    lx.LineNumber = lineNumber++;
                                    lx.Subtotal = CalcSubtotal(lx, pros);

                                    string updateCmdStr =
                                        $"UPDATE [dbo].[InvoiceLines] SET [LineNumber] = {lx.LineNumber}, [Subtotal] = {lx.Subtotal} WHERE [Id] = {lx.InvoiceLineId}";

                                    var cmd = new SqlCommand(updateCmdStr, connection);
                                    await cmd.ExecuteNonQueryAsync();
                                }

                                i.Total = i.Lines.Sum(l => l.Subtotal);
                                if (i.GstApplies == true)
                                {
                                    i.GstAmount = i.Total * i.GstRate;
                                }
                                else
                                {
                                    i.GstAmount = 0;
                                }

                                string updateInvStr = $"UPDATE [dbo].[Invoices] SET [Total] = {i.Total}, [GstAmount] = {i.GstAmount} WHERE [Id] = {i.Id}";
                                var invCmd = new SqlCommand(updateInvStr, connection);
                                await invCmd.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    connection.Close();

                    return i;
                }
                else
                {
                    Logger.Error("no invoice number");
                    throw new ArgumentNullException("invoiceNumber");
                }
            }
            else
            {
                Logger.Error("line is null");
                throw new ArgumentNullException("line");
            }
        }


        private static decimal CalcSubtotal(DbInvoiceLine line, List<SqlProduct> products)
        {
            var product = products.FirstOrDefault(x => x.SKU == line.SKU);
            
            if (product != null)
                return line.Quantity * product.UnitPrice;
            else
                return line.Subtotal;
        }
    }
}
