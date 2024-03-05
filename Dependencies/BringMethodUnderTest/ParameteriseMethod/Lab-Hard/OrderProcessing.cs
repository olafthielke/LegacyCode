using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.SystemFunctions;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab_Hard
{
    public class OrderProcessing
    {
        public string ApiKey { get; set; }

        public OrderProcessing(string apiKey)
        {
            ApiKey = apiKey;
        }

        public async Task<bool> ProcessOrder(Order order)
        {
            await ValidateOrder(order);

            order.ProcessingDate = DateTime.UtcNow;

            var paymentResult = await ProcessPayment(order, ApiKey);
            if (paymentResult)
            {
                EmailCustomerPaymentSuccessful(order, paymentResult);
            }
            else
            {
                EmailCustomerPaymentFailure(order, paymentResult);
            }

            return paymentResult;
        }


        private async Task ValidateOrder(Order order)
        {
            // TODO: This method takes a long time to run even for orders that allow partial fulfillment.
            // Find out why that might be and fix it.
            //
            // Please write unit tests first to ensure any optimisations
            // do not break existing behaviour.

            if (order == null)
                throw new ArgumentException("Order cannot be null.");

            if (order.Items == null || !order.Items.Any())
                throw new ArgumentException("Order must contain at least one item.");

            var inventoryChecker = new InventoryChecker();

            foreach (var item in order.Items)
            {
                var availableStock = await inventoryChecker.CheckAvailableStock(item.ItemId);

                if (!order.AllowPartialFulfillment && item.Quantity > availableStock)
                    throw new InvalidOperationException($"Item {item.ItemId} does not have sufficient stock.");
            }
        }

        private async Task<bool> ProcessPayment(Order order, string apiKey)
        {
            var paymentGateway = new PaymentGateway(apiKey);

            var customer = CustomerLookup.LookupCustomer(order.CustomerId);
            
            var paymentResult = await paymentGateway.ProcessPayment(customer, order);

            if (paymentResult == PaymentResult.Successful ||
                paymentResult == PaymentResult.Queued)
                return true;
            else
                return false;
        }

        private void EmailCustomerPaymentSuccessful(Order order, bool paymentResult)
        {
            var customer = CustomerLookup.LookupCustomer(order.CustomerId);
            
            var emailService = new EmailService();
            var email = new MailMessage(
                "donotreply@example.com",
                customer.EmailAddress,
                "Payment Successful", 
                $"Your order {order.IsDefined()} has been successfully processed."
            );

            _ = emailService.Send(email).Result;
        }

        private void EmailCustomerPaymentFailure(Order order, bool paymentResult)
        {
            var customer = CustomerLookup.LookupCustomer(order.CustomerId);

            var emailService = new EmailService();
            var email = new MailMessage(
                "donotreply@example.com",
                customer.EmailAddress,
                "Payment Failed",
                $"Your order {order.Id} has failed to process."
            );
            
            _ = emailService.Send(email).Result;
        }
    }
}
