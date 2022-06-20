using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.ExtractInterface.Lab
{
    public class MoneyTransfer
    {
        private Currency _currency;
        private Currency _transactionCurrency;

        private int _payWindow;

        public async Task<PayPalAccessToken> ConfigurePayPal(bool isProd, int paymentWindow, string status)
        {
            //_transactionCurrency = txCurrency;
            //_payWindow = paymentWindow;

            const string sandbox = "https://api.sandbox.paypal.com";
            const string production = "https://api.paypal.com";

            var http = new HttpClient();
            if (isProd == true)
            {
                http.BaseAddress = new Uri(production);
                http.Timeout = TimeSpan.FromSeconds(30);
            }
            else
            {
                http.BaseAddress = new Uri(sandbox);
                http.Timeout = TimeSpan.FromSeconds(30);
            }

            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes($"Kk97b1iibQ9iZuwYTbyK:19s6HCaQHjKfbkG90yit");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            };

            request.Content = new FormUrlEncodedContent(form);

            HttpResponseMessage response = await http.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }

            string content = await response.Content.ReadAsStringAsync();

            var accessToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);
            return accessToken;
        }
    }

    public class PayPalAccessToken
    {
        public string scope { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string app_id { get; set; }
        public int expires_in { get; set; }
        public string nonce { get; set; }
    }
}
