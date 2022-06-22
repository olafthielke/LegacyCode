using System;

namespace Dependencies.BringMethodUnderTest.PassNull.Demo
{
    public class MissingDeliveryAddress : Exception
    {
        public MissingDeliveryAddress(string custNo) 
            : base($"No Delivery Address for customer '{custNo}'!") 
        { }
    }
}
