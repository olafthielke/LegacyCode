using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dependencies.BringClassUnderTest.ExtractInterface.Lab;
using Newtonsoft.Json;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab_Hard
{
    public class PaymentGateway
    {
        private string _apiKey;
        
        public PaymentGateway(string apiKey)
        {
            _apiKey = apiKey;
        }
        
        public async Task<PaymentResult> ProcessPayment(DbCustomer customer, Order order, bool isProd = true)
        {
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

            var paymentToken = JsonConvert.DeserializeObject<PayPalAccessToken>(content);
            if (paymentToken == null)
            {
                throw new Exception("Failed to retrieve payment token.");
            }

            return PaymentResult.Successful;
        }
    }
}
