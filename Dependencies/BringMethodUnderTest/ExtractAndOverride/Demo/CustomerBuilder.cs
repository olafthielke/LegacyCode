using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public class CustomerBuilder
    {
        private ICustomerDetailsRetriever _customerDetailsRetriever;

        public CustomerBuilder() 
            : this(new CustomerDetailsRetriever())
        { }

        public CustomerBuilder(ICustomerDetailsRetriever customerDetailsRetriever)
        {
            _customerDetailsRetriever = customerDetailsRetriever;
        }

        public async Task<Customer> BuildCustomer(string customerNo)
        {
            var det = await _customerDetailsRetriever.GetCustomerDetails(customerNo);

            // TODO: We want to change the address type to "POSTAL" (also on Customer). How do we unit test that it's
            // currently "PRIMARY"? And then change the test to verify "POSTAL" and then change the
            // code to "POSTAL"?
            var add = await CustomerAddressGetter.GetAddress(customerNo, "PRIMARY");

            return new Customer
            {
                FirstName = det.FirstName,
                LastName = det.LastName,
                CustomerNumber = det.CustomerNumber,
                LoyaltyScore = det.LoyaltyPoints,
                AddressType = "PRIMARY",
                Address = $"{add.StreetNumber} {add.StreetName}, {add.Suburb}, {add.TownOrCity} {add.PostCode}"
            };
        }
    }
}