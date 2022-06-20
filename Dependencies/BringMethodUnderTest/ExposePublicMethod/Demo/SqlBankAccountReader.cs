using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExposePublicMethod.Demo
{
    public class SqlBankAccountReader
    {
        public string ConnectionString { get; set; }

        public SqlBankAccountReader(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<BankAccount> GetBankAccount(string accNo)
        {
            var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            var sqlcmd = new SqlCommand($"SELECT * FROM [dbo].[Accounts] WHERE [AccountNumber] = '{accNo}'", connection);

            var reader = await sqlcmd.ExecuteReaderAsync();

            var sqlReader = new SqlCustomerReader(reader);
            BankAccount account = null;

            if (reader.Read())
            {

                var number = reader["AccountNumber"].ToString();

                var name = reader["AccountName"].ToString();
                var balance = Convert.ToDecimal(reader["Balance"].ToString());

                account = new BankAccount()
                {
                    AccountName = name,
                    AccountNumber = number,

                    Balance = balance
                };

                return account;
            }

            connection.Close();

            return null;
        }
    }
}
