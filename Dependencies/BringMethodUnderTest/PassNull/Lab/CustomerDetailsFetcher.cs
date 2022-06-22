using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.PassNull.Lab
{
    public class CustomerDetailsFetcher
    {
        private const string ConnectionStringName = "CustomerDB";
        private string ConnectionString { get; }

        public CustomerDetailsFetcher()
        {
            var connStringSetting = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (connStringSetting == null)
                throw new Exception("Error retrieving connection string for 'CustomerDB'.");

            ConnectionString = connStringSetting.ConnectionString;
        }

        public async Task<CustomerDetails> FetchDetails(string customerNumber)
        {
            var details = new CustomerDetails();

            await using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var sqlcmd = new SqlCommand($"SELECT * FROM [dbo].[Customers] WHERE [CustomerNumber] = '{customerNumber}'", connection);

                var reader = await sqlcmd.ExecuteReaderAsync();

                // read customer details

                // ...
            }

            return details;
        }
    }
}
