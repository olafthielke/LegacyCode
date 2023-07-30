using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public class TestCustomerBuilder : CustomerBuilder
    {
        private Address Address { get; }

        public bool WasGetAddressCalled { get; private set; }

        public string PassedInCustomerNo { get; private set; }
        public string PassedInAddressType { get; private set; }

        public TestCustomerBuilder(ICustomerDetailsRetriever customerDetailsRetriever, Address address)
            : base(customerDetailsRetriever)
        {
            Address = address;
        }


        protected override async Task<Address> GetAddress(string customerNo, string addressType)
        {
            WasGetAddressCalled = true;
            PassedInCustomerNo = customerNo;
            PassedInAddressType = addressType;

            return Address;
        }
    }
}
