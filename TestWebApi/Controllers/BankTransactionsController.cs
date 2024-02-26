using System;
using System.Threading.Tasks;
using Dependencies.BringClassUnderTest.Wrapper.Lab;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;
using Transaction = System.Transactions.Transaction;

namespace TestWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankTransactionsController : ControllerBase
    {
        private static readonly string _connectionString = "Data Source=(local);Initial Catalog=Banking;Integrated Security=true";

        private readonly XyzBankTransactionService _xyzBankTransactionService = new XyzBankTransactionService();
        
        

        [HttpPost]
        public async Task<BankTransaction> Create(BankTransaction transaction)
        {
            if (transaction == null)
                throw new Exception("Transaction is required.");
            if (string.IsNullOrWhiteSpace(transaction.Particulars))
                throw new Exception("Particulars is required.");

            if (transaction.Amount == 0)
                throw new Exception("0 is not a valid transaction amount.");

            var accountReader = new SqlBankAccountReader(_connectionString);
            var bankAccount = await accountReader.GetBankAccount(transaction.AccountNumber);
            
            if (bankAccount == null)
                throw new Exception($"{transaction.AccountNumber} is not a valid account number.");

            if (bankAccount.Balance + transaction.Amount < 0)
                throw new Exception($"Account '{bankAccount.AccountNumber}' has insufficient funds for this transaction.");

            transaction.TransactionDate = DateTime.Today;

            await SqlBankTransactionWriter.SaveTransaction(transaction, _connectionString);

            return transaction;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string accountNumber, int page = 1)
        {
            var tx = await _xyzBankTransactionService.GetTransactions(accountNumber, page);

            return Ok(tx);
        }
    }
}
