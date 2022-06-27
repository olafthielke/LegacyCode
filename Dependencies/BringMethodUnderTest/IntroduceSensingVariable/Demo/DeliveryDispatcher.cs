using LegacyLibrary.Delivery;

namespace Dependencies.BringMethodUnderTest.IntroduceSensingVariable.Demo
{
    public class DeliveryDispatcher
    {
        public bool Init(string town, string suburb)
        {
            // Lots of nasty hard to understand code in here.

            // ...

            var delivery = new LegacyPostcodeDelivery(town, suburb);

            // ...

            return delivery.IsInitialised();
        }

        public void FulfillOrder(CustomerOrder order, string deliveryAddress)
        {

        }
    }
}
