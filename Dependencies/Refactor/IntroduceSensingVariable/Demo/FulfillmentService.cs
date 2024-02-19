using LegacyLibrary.Delivery;

namespace Dependencies.Refactor.IntroduceSensingVariable.Demo
{
    public class FulfillmentService
    {
        public DeliveryDispatcher DeliveryDispatcher { get; set; }

        public FulfillmentService()
        {
            DeliveryDispatcher = new DeliveryDispatcher();
        }

        // TODO: We want to extract the formatting of the deliveryAddress string into its own method.
        public void Deliver(Address address, CustomerOrder order)
        {
            // Build address string
            var deliveryAddress = "";

            if (!string.IsNullOrEmpty(address.Level))
            {
                deliveryAddress += "Level " + address.Level + ", ";
            }

            if (!string.IsNullOrEmpty(address.Building))
            {
                deliveryAddress += address.Building + ", ";
            }

            deliveryAddress += address.StreetNo + " " + address.Street + ", ";

            if (!string.IsNullOrEmpty(address.Suburb))
            {
                deliveryAddress += address.Suburb + ", " + address.Town;
            }

            // Does this call to DeliveryDispatcher.Init() change our addressString?
            DeliveryDispatcher.Init(address.Town, address.Suburb);

            deliveryAddress += " " + GetPostCode(); // <- Does deliveryDispatcher.Init() affect the post code?

            // TODO

            // From here on, we use the DeliveryDispatcher to fulfill the order and deliver the goods.
            if (order != null)
            {
                // ...


                DeliveryDispatcher.FulfillOrder(order, deliveryAddress);

                // ...
            }
        }


        private int GetPostCode()
        {
            // This is a really messy and long method.
            // It's hard to work out what is going on.

            // ...

            var tracker = LegacyDeliveryTracker.AcquireCurrent();

            // ...

            return tracker.PostCode;
        }
    }
}
