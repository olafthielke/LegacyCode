using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public class CustomerBuilderTests
    {
        // Characterisation Test
        [Fact]
        public async Task Test_BuildCustomer()
        {
            var details = BuildCustomerDetails();
            var address = BuildCustomerAddress();
            var mockCustomerDetailsRetriever = new FakeCustomerDetailsRetriever(details);
            var builder = new TestCustomerBuilder(mockCustomerDetailsRetriever, address);

            var customer = await builder.BuildCustomer("123456");

            VerifyCustomer(customer);
        }

        // Specific Test
        [Fact]
        public async Task Build_Customer_With_Primary_Address() // Then change to Postal
        {
            var details = BuildCustomerDetails();
            var address = BuildCustomerAddress();
            var mockCustomerDetailsRetriever = new FakeCustomerDetailsRetriever(details);
            var builder = new TestCustomerBuilder(mockCustomerDetailsRetriever, address);

            var customer = await builder.BuildCustomer("123456");

            const string addressType = "PRIMARY";
            customer.AddressType.Should().Be(addressType);
            builder.PassedInAddressType.Should().Be(addressType);
        }


        private static CustomerDetails BuildCustomerDetails()
        {
            return new CustomerDetails
            {
                CustomerNumber = "123456",
                FirstName = "Fred",
                LastName = "Flintstone",
                LoyaltyPoints = 9876
            };
        }
        private static Address BuildCustomerAddress()
        {
            return new Address
            {
                StreetNumber = "17C",
                StreetName = "Queen St",
                Suburb = "CBD",
                TownOrCity = "Auckland",
                PostCode = 1000
            };
        }


        private static void VerifyCustomer(Customer customer)
        {
            customer.FirstName.Should().Be("Fred");
            customer.LastName.Should().Be("Flintstone");
            customer.CustomerNumber.Should().Be("123456");
            customer.LoyaltyScore.Should().Be(9876);
            customer.AddressType.Should().Be("PRIMARY");
            customer.Address.Should().Be("17C Queen St, CBD, Auckland 1000");
        }
    }


    public class FakeCustomerDetailsRetriever : ICustomerDetailsRetriever
    {
        private CustomerDetails CustomerDetails { get; }

        public FakeCustomerDetailsRetriever(CustomerDetails customerDetails)
        {
            CustomerDetails = customerDetails;
        }

        public async Task<CustomerDetails> GetCustomerDetails(string customerNumber)
        {
            return CustomerDetails;
        }
    }
}
