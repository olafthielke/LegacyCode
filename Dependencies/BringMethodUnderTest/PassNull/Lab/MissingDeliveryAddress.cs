using System;

namespace Dependencies.BringMethodUnderTest.PassNull.Lab
{
    public class MissingDeliveryAddress : Exception
    {
        public MissingDeliveryAddress(string custNo) 
            : base($"No Delivery Address for customer '{custNo}'!") 
        { }
    }
}
