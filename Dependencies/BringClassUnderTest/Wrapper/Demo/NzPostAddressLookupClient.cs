using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.Wrapper.Demo
{
    public class NzPostAddressLookupClient
    {
        public string ApiClientId { get; set; }
        public string ApiClientSecret { get; set; }

        public HttpClient Client { get; } = new HttpClient();


        private const string AddressFinderUrl = "https://not-real-api.nzpost.co.nz/addressfinder/";


        public NzPostAddressLookupClient()
        {
            try
            {
                var response = Client.GetStringAsync(AddressFinderUrl).Result;

                if (!response.StartsWith("ADDRESS RESULT"))
                    throw new InvalidOperationException("NZ Post Service unavailable.");
                
                Debug.WriteLine("NZ Post Service is available.");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("NZ Post Service unavailable.");
            }
        }


        public async Task<string> LookupAddress(string addressFragment)
        {
            // TODO: We need to switch to the version 2 of the API. Version 2 uses a v=2 query parameter.
            string requestUrl = AddressFinderUrl + "?address=" + Uri.EscapeDataString(addressFragment);
            try
            {
                var response = await Client.GetStringAsync(requestUrl);
                if (response.StartsWith("ADDRESS RESULT"))
                {
                    return response.Substring("ADDRESS RESULT: ".Length);
                }
                throw new InvalidOperationException("NZ Post Service lookup failed.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
