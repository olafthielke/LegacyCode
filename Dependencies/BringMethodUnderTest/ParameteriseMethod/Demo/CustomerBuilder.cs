using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Demo
{
    public class CustomerBuilder
    {
        private readonly CustomerDetailsRetriever _customerDetailsRetriever;

        public CustomerBuilder()
        {
            _customerDetailsRetriever = new CustomerDetailsRetriever();
        }

        public async Task<Customer> BuildCustomer(string customerNo)
        {
            // TODO: Write unit test covering the data retrieval.
            // Please verify that GetCustomerDetails and GetAddress are called
            // with the correct customer number and address type.
            
            var det = await _customerDetailsRetriever.GetCustomerDetails(customerNo);

            var addressGetter = new CustomerAddressGetter();
            var add = await addressGetter.GetAddress(customerNo, "PRIMARY");

            return new Customer
            {
                FirstName = det.FirstName,
                LastName = det.LastName,
                //FullName = $"{det.FirstName} {det.LastName}",
                CustomerNumber = det.CustomerNumber,
                LoyaltyScore = det.LoyaltyPoints,
                AddressType = "PRIMARY",
                Address = $"{add.StreetNumber} {add.StreetName}, {add.Suburb}, {add.TownOrCity} {add.PostCode}"
            };
        }
    }
}
