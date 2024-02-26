using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LegacyLibrary.WebClient;
using Microsoft.OData.UriParser;
using Newtonsoft.Json;

namespace Dependencies.BringClassUnderTest.Wrapper.Lab
{
    public class XyzBankTransactionService
    {
        public LegacyWebClient Client { get; } = new LegacyWebClient();


        private static readonly Uri AuthUrl = new Uri("https://not-real-api.xyzbank.com.au/auth/");
        
        private string _authToken = string.Empty;

        public XyzBankTransactionService()
        {
            // Synchronous network call in the constructor - not a good practice
            try
            {
                _authToken = Client.GetString(AuthUrl.AbsoluteUri);
                Debug.WriteLine("Authenticated successfully.");
            }
            catch
            {
                Trace.WriteLine("Authentication failed.");
            }
        }


        public async Task<IList<Transaction>> GetTransactions(string accountNumber, int pageNumber = 1)
        {
            IList<Transaction> transactions = new List<Transaction>();

            string transactionUrl = $"https://not-real-api.xyzbank.com.au/accounts/{accountNumber}/transactions?page={pageNumber}&auth={_authToken}";
            try
            {
                // Here we should use _authToken, but it's just hard-coded for simplicity
                string json = Client.GetString(transactionUrl);

                Debug.WriteLine("Transactions fetched successfully.");

                transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);
            }
            catch
            {
                // Simplified error handling, real-world scenario would need more detailed handling
                Trace.WriteLine("Failed to fetch transactions.");
            }

            return transactions;
        }
    }
}
