using System.Net.Http;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.PrimitiviseParameter.Lab
{
    public class NzPostAddressLookupClient
    {
        public string ApiClientId { get; set; }
        public string ApiClientSecret { get; set; }

        public HttpClient Client { get; } = new HttpClient();


        private const string AddressFinderUrl = "https://not-real-api.nzpost.co.nz/addressfinder/";


        public NzPostAddressLookupClient()
        {
            // This is made up. The point here is that this constructor 
            // makes a call to a remote service and therefore this class
            // should be side-stepped by our class instantiating it.
            // Will make any test SLOW, FRAGILE, and an INTEGRATION TEST. AVOID.
            var response = Client.GetStringAsync(AddressFinderUrl).Result;

            // Say, we need to check the response for some OK type result.
        }


        public async Task<string> LookupAddress(string addressFragment)
        {
            // call, say, the NZ Post Address lookup service. 

            return null;
        }
    }
}
