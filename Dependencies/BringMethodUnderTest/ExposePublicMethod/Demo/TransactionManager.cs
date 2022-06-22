using System;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExposePublicMethod.Demo
{
    public class TransactionManager
    {
        public string ConnectionString { get; set; }

        public TransactionManager(string connectionString)
        {
            ConnectionString = connectionString;
        }


        public async Task<BankTransaction> Create(BankTransaction transaction)
        {
            // TODO: Would rather just test Validate but it's a private method.
            await Validate(transaction);


            transaction.TransactionDate = DateTime.Today;

            await SqlBankTransactionWriter.SaveTransaction(transaction, ConnectionString);

            // ...

            // ... Many more hard-to-break dependencies. :(

            return transaction;
        }

        public async Task Validate(BankTransaction transaction)
        {
            if (transaction == null)
                throw new Exception("Transaction is required.");
            if (string.IsNullOrWhiteSpace(transaction.Description))
                throw new Exception("Particulars is required.");

            // TODO: We want to validate the transaction.TransactionAmount and if it is 0,
            // then throw a "0 is not a valid transaction amount." exception.

            var accountReader = new SqlBankAccountReader(ConnectionString);
            var bankAccount = await accountReader.GetBankAccount(transaction.AccountNumber);

            if (bankAccount == null)
                throw new Exception($"{transaction.AccountNumber} is not a valid account number.");

            if (bankAccount.Balance + transaction.TransactionAmount < 0)
                throw new Exception($"Account '{bankAccount.AccountNumber}' has insufficient funds for this transaction.");
        }
    }
}
