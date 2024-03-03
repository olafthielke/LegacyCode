using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExposePublicMethod.Lab
{
    public class CustomerBuilder
    {
        private CustomerDetailsRetriever _customerDetailsRetriever;

        public CustomerBuilder()
        {
            _customerDetailsRetriever = new CustomerDetailsRetriever();
        }

        public async Task<Customer> BuildCustomer(string customerNo)
        {
            var det = await _customerDetailsRetriever.GetCustomerDetails(customerNo);

            var add = await CustomerAddressGetter.GetAddress(customerNo, "PRIMARY");

            // TODO: We want to populate the FullName property on the Customer and are not really interested
            // in unit testing the data retrieval part.
            //
            // How do we unit test the returned Customer (first without and then with FullName) with the least hassle??
            return new Customer
            {
                FirstName = det.FirstName,
                LastName = det.LastName,
                //TODO: FullName = $"{det.FirstName} {det.LastName}", But with tests FIRST!
                CustomerNumber = det.CustomerNumber,
                LoyaltyScore = det.LoyaltyPoints,
                AddressType = "PRIMARY",
                Address = $"{add.StreetNumber} {add.StreetName}, {add.Suburb}, {add.TownOrCity} {add.PostCode}"
            };
        }
    }
}
