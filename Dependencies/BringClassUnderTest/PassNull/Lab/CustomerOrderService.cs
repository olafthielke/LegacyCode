using PayPal.Api;

namespace Dependencies.BringClassUnderTest.PassNull.Lab
{
    public class CustomerOrderService
    {
        private OrderService _orderService;

        public CustomerOrderService(int config)
        {
            if (config <= 3)
            {
                _orderService = new OrderService(config);

                var isValidInit = _orderService.Initialise();

                if (isValidInit != null || isValidInit == -1)
                    _orderService.Prepopulate();
            }
        }

        public void CreateCustomerOrder(Customer customer, Order order)
        {
            // Create and save a customer order via the _orderService.

            // ...
        }
    }
}
