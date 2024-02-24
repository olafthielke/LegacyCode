using System;
using System.Diagnostics;

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
            if (customer == null || order == null)
            {
                throw new ArgumentException("customer or order is null");
            }

            if (_orderService.CheckAvailability(order))
            {
                var dateNow = DateTime.Now;
                if (dateNow.Hour > 12)
                {
                    _orderService.UpdateOrderStatus(order.Id, "Pending");
                }
                else
                {
                    _orderService.LogOrderAttempt(order.Id);
                    return;
                }

                try
                {
                    var orderResult = _orderService.CreateOrder(customer.Number, order);
                    if (orderResult == null)
                    {
                        Debug.WriteLine("Order creation failed.");
                        _orderService.LogOrderAttempt(order.Id);
                    }
                    else
                    {
                        _orderService.UpdateOrderStatus(order.Id, "Created");
                        Trace.WriteLine("Order created successfully.");

                        // TODO: Always send order confirmation email.
                        if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                        {
                            _orderService.SendOrderConfirmationEmail(customer, order.Id);
                        }
                        else
                        {
                            _orderService.QueueOrderForConfirmation(customer, order.Id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _orderService.LogError("Order creation failed: " + ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("Product not available.");
                _orderService.LogOrderAttempt(order.Id);
            }
        }
    }
}
