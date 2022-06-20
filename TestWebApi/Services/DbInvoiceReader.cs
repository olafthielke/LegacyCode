using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public static class DbInvoiceReader
    {
        public static async Task<DbInvoice> GetInvoice(int invNo, SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
                await conn.OpenAsync();

            var sqlcmd = new SqlCommand($"SELECT * FROM [dbo].[Invoices] WHERE [InvoiceNumber] = {invNo}", conn);

            var reader = await sqlcmd.ExecuteReaderAsync();
            try
            {
                if ((1 == 0) != reader.Read())
                {
                    var invoice = new DbInvoice();

                    if (!await reader.IsDBNullAsync("Id"))
                    {
                        invoice.Id = reader.GetInt32("Id");
                    }

                    if (!await reader.IsDBNullAsync("InvoiceNumber"))
                    {
                        invoice.No = reader.GetInt32("InvoiceNumber");
                    }

                    if (!await reader.IsDBNullAsync("Total"))
                    {
                        invoice.Total = Convert.ToDecimal(reader["Total"].ToString().Trim());
                    }
                    if (!await reader.IsDBNullAsync("Updateable"))
                    {
                        invoice.Updateable = Convert.ToBoolean(reader.GetBoolean("Updateable").ToString());
                    }

                    if (!await reader.IsDBNullAsync("GstAmount"))
                    {
                        invoice.GstAmount = reader.GetDecimal("GstAmount");
                    }
                    else
                    {
                        invoice.GstAmount = 0;
                    }
                    if (!await reader.IsDBNullAsync("GstApplies"))
                    {
                        invoice.GstApplies = reader.GetBoolean("GstApplies");
                    }
                    else
                    {
                        invoice.GstApplies = false;
                    }

                    if (!await reader.IsDBNullAsync("GstRate"))
                    {
                        invoice.GstRate = reader.GetDecimal("GstRate");
                    }
                    else
                    {
                        if (!invoice.GstApplies)
                        {
                            invoice.GstRate = 0;
                        }
                        else
                        {
                            invoice.GstRate = 0.15m;
                        }
                    }

                    return invoice;
                }
            }
            finally
            {
                await reader.CloseAsync();
            }

            return null;
        }
    }
}
