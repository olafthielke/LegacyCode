using Xunit;

namespace Dependencies.Refactor.IntroduceSensingVariable.Demo
{
    public class FulfillmentServiceTests
    {
        [Fact]
        public void Test_Auckland_DBD_DeliveryAddress_Formatting()
        {
            var svc = new FulfillmentService();
            var address = new Address()
            {
                Level = "7",
                Building = "Lister Building",
                StreetNo = "43",
                Street = "Queen St",
                Suburb = "CBD",
                Town = "Auckland"
            };
            svc.Deliver(address, null);
            // ???
        }

        [Fact]
        public void Test_Wellington_CBD_DeliveryAddress_Formatting()
        {
            var svc = new FulfillmentService();
            var address = new Address()
            {
                StreetNo = "9",
                Street = "Cuba St",
                Suburb = "CBD",
                Town = "Wellington"
            };
            svc.Deliver(address, null);
            // ???
        }
    }
}
