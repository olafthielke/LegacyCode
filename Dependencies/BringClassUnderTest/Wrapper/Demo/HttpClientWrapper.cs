using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.Wrapper.Demo
{
    public class HttpClientWrapper : IHttpClient
    {
        private HttpClient Client { get; }

        public HttpClientWrapper()
        {
            Client = new HttpClient();
        }


        public async Task<string> GetStringAsync(string requestUri)
        {
            return await Client.GetStringAsync(requestUri);
        }
    }
}
