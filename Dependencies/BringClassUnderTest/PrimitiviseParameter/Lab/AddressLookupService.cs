using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.PrimitiviseParameter.Lab
{
    public class AddressLookupService
    {
        private NzPostAddressLookupClient AddressClient { get; }

        public AddressLookupService(ConnectionStringConfig config)
        {
            var apiKey = ConfigurationManager.AppSettings["NzPostApiKey"];
            var apiKeys = apiKey.Split('-');

            AddressClient = new NzPostAddressLookupClient();

            AddressClient.ApiClientId = apiKeys[0];
            AddressClient.ApiClientSecret = apiKeys[1];
            AddressClient.ConnectionString = config.DatabasesConfig.DatabaseConfig.ConnectionString;

            // ...
        }


        // Want to make changes in this method!
        public async Task<string> LookupAddress(string addressFragment)
        {
            if (string.IsNullOrWhiteSpace(addressFragment))
            {
                return "Address fragment must not be empty.";
            }

            try
            {
                // Makes call to AddressClient to look up addressFragment.
                var address = await AddressClient.LookupAddress(addressFragment);

                if (string.IsNullOrWhiteSpace(address))
                {
                    return "No address found matching the provided fragment.";
                }

                return address;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during address lookup: {ex.Message}");

                return "An error occurred while trying to look up the address. Please try again later.";
            }
        }
    }
}