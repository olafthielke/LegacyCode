using System.Configuration;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.PrimitiviseParameter.Lab
{
    public class AddressLookupService
    {
        private NzPostAddressLookupClient AddressClient { get; }

        public AddressLookupService()
        {
            var apiKey = ConfigurationManager.AppSettings["NzPostApiKey"];
            var apiKeys = apiKey.Split('-');

            AddressClient = new NzPostAddressLookupClient();

            AddressClient.ApiClientId = apiKeys[0];
            AddressClient.ApiClientSecret = apiKeys[1];

            // ...
        }


        // Want to make changes in this method!
        public async Task<string> LookupAddress(string addressFragment)
        {
            // ...

            // makes call to AddressClient to look up addressFragment.
            var address = await AddressClient.LookupAddress(addressFragment);

            // ...

            return address;
        }
    }
}