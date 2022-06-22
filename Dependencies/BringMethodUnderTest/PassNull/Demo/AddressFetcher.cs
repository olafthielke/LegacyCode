using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.PassNull.Demo
{
    public class AddressFetcher
    {
        private const string ConnectionStringName = "AddressesDB";
        private string ConnectionString { get; }

        public AddressFetcher()
        {
            var connStringSetting = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (connStringSetting == null)
                throw new Exception("Error retrieving connection string for 'AddressesDB'.");

            ConnectionString = connStringSetting.ConnectionString;
        }


        public async Task<Address> FetchAddress(string geoCode, string type)
        {
            var address = new Address();

            await using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var sqlcmd = new SqlCommand($"SELECT * FROM [dbo].[Addresses] WHERE [GeoCode] = '{geoCode}'", connection);

                var reader = await sqlcmd.ExecuteReaderAsync();

                // read address

                // ...
            }

            return address;
        }
    }
}
