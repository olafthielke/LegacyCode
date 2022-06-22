using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.PassNull.Lab
{
    public class LoyaltySchemeFetcher
    {
        private const string ConnectionStringName = "LoyaltyDB";
        private string ConnectionString { get; }

        public LoyaltySchemeFetcher()
        {
            var connStringSetting = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (connStringSetting == null)
                throw new Exception("Error retrieving connection string for 'LoyaltyDB'.");

            ConnectionString = connStringSetting.ConnectionString;
        }


        public async Task<LoyaltyMembership> FetchLoyalty(string loyaltyNo)
        {
            var loyalty = new LoyaltyMembership();

            await using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var sqlcmd = new SqlCommand($"SELECT * FROM [dbo].[Members] WHERE [LoyaltyNumber] = '{loyaltyNo}'", connection);

                var reader = await sqlcmd.ExecuteReaderAsync();

                // read loyalty

                // ...
            }

            return loyalty;
        }
    }
}
