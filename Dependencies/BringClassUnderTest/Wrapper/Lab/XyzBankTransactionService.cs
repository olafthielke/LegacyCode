using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.Wrapper.Lab
{
    public class XyzBankTransactionService
    {
        public HttpClient Client { get; } = new HttpClient();


        private static readonly Uri AuthUrl = new Uri("https://not-real-api.xyzbank.com.au/auth/");


        public XyzBankTransactionService()
        {
            var response = Client.GetStringAsync(AuthUrl).Result;

            // ...
        }


        public async Task<IList<Transaction>> GetTransactions(string accountNumber)
        {
            // ...

            return null;
        }
    }
}
