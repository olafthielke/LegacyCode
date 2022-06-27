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

            // TODO: We want to wrap unit tests around this method, LookupAddress(), yet LegacyWebClient
            // is stopping us since it's trying to do Network IO. Furthermore, LegacyWebClient doesn't
            // have a usable interface (or abstract base class) and it isn't our code so we can't add an
            // interface. What do we do?
            var client = new LegacyWebClient();

            var response = client.GetString(AddressServiceBaseUrl + addressFragment);

            address = JsonConvert.DeserializeObject<Address>(response);

            // ...

            return address;
        }
    }
}
