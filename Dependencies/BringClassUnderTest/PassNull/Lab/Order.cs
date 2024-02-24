using System.Collections.Generic;

namespace Dependencies.BringClassUnderTest.PassNull.Lab
{
    public class Order
    {
        public int Id { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();


        public void Add(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
