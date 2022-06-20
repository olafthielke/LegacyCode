using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public class CustomerBuilder
    {
        public async Task<Customer> BuildCustomer(string customerNo)
        {
            var det = await new CustomerDetailsRetriever().GetCustomerDetails(customerNo);

            var add = await CustomerAddressRetriever.GetAddress(customerNo, "PRIMARY");

            return new Customer
            {
                FirstName = det.FirstName,
                LastName = det.LastName,
                FullName = det.FirstName + " " + det.LastName,
                CustomerNumber = det.CustomerNumber,
                LoyaltyScore = det.LoyaltyPoints,
                AddressType = "PRIMARY",
                Address = $"{add.StreetNumber} {add.StreetName}, {add.Suburb}, {add.TownOrCity} {add.PostCode}"
            };
        }
    }
}
