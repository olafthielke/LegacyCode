using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class InvoiceLinesService
    {
        private SqlConnection Connection { get; }


        public InvoiceLinesService(SqlConnection sqlConnection)
        {
            Connection = sqlConnection;
        }


        public async Task<List<DbInvoiceLine>> GetInvoiceLines(string cmdTxt, SqlConnection conn = null)
        {
            conn ??= Connection;

            var cmd = new SqlCommand(cmdTxt, conn);

            var reader = await cmd.ExecuteReaderAsync();
            try
            {

                var lines = new List<DbInvoiceLine>();
                while (reader.Read() == true)
                {
                    var lId = reader.GetInt32("Id");
                    var invoiceNo = reader.GetInt32("InvoiceNumber");
                    var pId = Convert.ToInt32(reader["ProductId"].ToString());
                    var pName = reader["ProductName"].ToString();
                    var quantity = reader.GetInt32("Quantity");

                    var pSKU = reader["ProductSKU"].ToString();
                    int lineNo = reader.GetInt32("LineNumber");

                    lines.Add(new DbInvoiceLine()
                    {
                        InvoiceLineId = lId,
                        InvoiceNumber = invoiceNo,
                        ProductId = pId,
                        Quantity = quantity,

                        ProductName = pName?.Trim(),
                        SKU = pSKU.Trim(),

                        Subtotal = Convert.ToDecimal(reader["Subtotal"].ToString()),
                        LineNumber = lineNo
                    });
                }

                return lines;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
