using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Demo
{
    public static class SqlBankTransactionWriter
    {
        public static async Task SaveTransaction(BankTransaction tx, string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            var savecmd = new SqlCommand($"INSERT INTO [dbo].[Transactions] ([AccountNumber], [Amount], [Particulars], [TransactionDate]) VALUES ('{tx.AccountNumber}', '{tx.TransactionAmount}', '{tx.Description}', '{tx.TransactionDate}')", connection);

            await savecmd.ExecuteNonQueryAsync();

            connection.Close();
        }
    }
}
