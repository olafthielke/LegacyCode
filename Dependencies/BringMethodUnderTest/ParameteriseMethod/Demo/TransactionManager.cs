using System;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Demo
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
            if (transaction.TransactionAmount == 0)
                throw new Exception("0 is not a valid transaction amount.");

            var accountReader = new SqlBankAccountReader(ConnectionString);
            var bankAccount = await accountReader.GetBankAccount(transaction.AccountNumber);

            if (bankAccount == null)
                throw new Exception($"{transaction.AccountNumber} is not a valid account number.");

            // TODO: This last conditional does not allow for the situation where the account is
            // already overdrawn and the transaction is a credit, paying down the overdraft. 
            if (bankAccount.Balance + transaction.TransactionAmount < 0)
                throw new Exception($"Account '{bankAccount.AccountNumber}' has insufficient funds for this transaction.");
        }
    }
}
