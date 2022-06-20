using PayPal.Api;

namespace Dependencies.BringClassUnderTest.PassNull.Lab
{
    public class CustomerOrderService
    {
        private OrderService OrderService { get; set; }

        public CustomerOrderService(int config)
        {
            if (config <= 3)
            {
                OrderService = new OrderService(config);

                var isValidInit = OrderService.Initialise();

                if (isValidInit != null || isValidInit == -1)
                    OrderService.Prepopulate();
            }
        }

        public void CreateCustomerOrder(Customer customer, Order order)
        {
            // Create and save a customer order via the OrderService.

            // ...
        }
    }
}
