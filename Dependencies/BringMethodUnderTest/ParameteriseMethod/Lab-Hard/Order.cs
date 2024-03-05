using System;
using System.Collections.Generic;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab_Hard
{
    public class Order
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime? ProcessingDate { get; set; }
        public bool AllowPartialFulfillment { get; set; }
    }
}
