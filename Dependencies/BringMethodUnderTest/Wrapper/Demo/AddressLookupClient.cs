using LegacyLibrary.WebClient;
using Newtonsoft.Json;

namespace Dependencies.BringMethodUnderTest.Wrapper.Demo
{
    public class AddressLookupClient
    {
        private const string AddressServiceBaseUrl = "https://ficticious.placefinder.com/maps/api/place/queryautocomplete/output?fragment=";


        public Address LookupAddress(string addressFragment)
        {
            Address address = null;

            // ...

            var client = new LegacyWebClient();

            var response = client.GetString(AddressServiceBaseUrl + addressFragment);

            address = JsonConvert.DeserializeObject<Address>(response);

            // ...

            return address;
        }
    }
}
