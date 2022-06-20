using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public class ProductManager
    {
        private SqlConnection Connection { get; }


        public ProductManager(SqlConnection sqlConnection)
        {
            Connection = sqlConnection;
        }


        public async Task<SqlProduct> GetProduct(string cmdTxt, SqlConnection conn = null)
        {
            conn ??= Connection;

            var cmd = new SqlCommand(cmdTxt, conn);
            var reader = await cmd.ExecuteReaderAsync();

            try
            {
                var prod = new SqlProduct();
                if (reader.Read())
                {
                    if (!await reader.IsDBNullAsync("SKU"))
                    {
                        prod.SKU = reader.GetString("SKU").Trim();
                    }

                    if (!await reader.IsDBNullAsync("Name"))
                    {
                        prod.Description = reader["Name"].ToString();
                    }

                    if (!await reader.IsDBNullAsync("UnitPrice"))
                    {
                        prod.UnitPrice = reader.GetDecimal("UnitPrice");
                    }
                }
                return prod;

            }
            finally
            {
                reader.Close();
            }

            return null;
        }
    }
}
