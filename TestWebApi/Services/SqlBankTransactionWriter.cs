using System.Data.SqlClient;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public static class SqlBankTransactionWriter
    {
        public static async Task SaveTransaction(BankTransaction tx, string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            var savecmd = new SqlCommand($"INSERT INTO [dbo].[Transactions] ([AccountNumber], [Amount], [Particulars], [TransactionDate]) VALUES ('{tx.AccountNumber}', '{tx.Amount}', '{tx.Particulars}', '{tx.TransactionDate}')", connection);

            await savecmd.ExecuteNonQueryAsync();

            connection.Close();
        }
    }
}
