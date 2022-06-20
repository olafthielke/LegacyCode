using System;
using System.Threading.Tasks;
using Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab;
using Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab.Additional;
using Dependencies.BringClassUnderTest.Wrapper.Lab;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BankTransactionsController : Controller
    {
        private const string SqlConnectionString = "Data Source=(local);Initial Catalog=Banking;Integrated Security=true";

        private XyzBankTransactionService TransactionService { get; }


        public BankTransactionsController()
        {
            TransactionService = new XyzBankTransactionService();

            // ...
        }



        [HttpPost]
        public async Task<BankTransaction> Create(BankTransaction transaction)
        {
            var accountReader = new SqlBankAccountReader(SqlConnectionString);
            var account = await accountReader.GetBankAccount(transaction.AccountNumber);

            var validator = new RegularAccountTransactionValidator();
            validator.Validate(transaction, account);

            // ...

            return transaction;
        }
    }
}
