using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExposePublicMethod.Lab
{
    public class CustomerBuilder
    {
        public async Task<Customer> BuildCustomer(string customerNo)
        {
            var det = await new CustomerDetailsRetriever().GetCustomerDetails(customerNo);

            var add = await CustomerAddressRetriever.GetAddress(customerNo, "PRIMARY");

            // TODO: We want to populate the FullName property on the Customer and are not really interested
            // in testing the data retrieval part. How do we do best/most easily do that??
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
