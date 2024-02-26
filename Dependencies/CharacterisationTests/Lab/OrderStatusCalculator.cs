using System;

namespace Dependencies.CharacterisationTests.Lab
{
    // TODO: Change the CalculateOrderStatus() method so that a customerFeedbackScore of 90 or more will result in an ExpressHandling status.
    // All other Order Status must not change!

    public class OrderStatusCalculator
    {
        public OrderStatus RecalculateOrderStatus(
            OrderStatus previousOrderStatus,
            DateTime orderDate,
            DateTime estimatedDeliveryDate, 
            int itemsInStock, 
            int updatedStockItems,
            int customerFeedbackScore, 
            bool shippingDelayResolved,
            int depth = 0)
        {
            // Base condition for recursion to prevent infinite loops
            if (depth > 3)
            {
                return OrderStatus.Processing; // Default to Processing if too deep
            }

            bool isPriorityCustomer = customerFeedbackScore > 80;
            bool isInStock = itemsInStock > 0;
            TimeSpan timeUntilEstimatedDelivery = estimatedDeliveryDate.Subtract(DateTime.Now);
            TimeSpan timeSinceOrderPlaced = DateTime.Now.Subtract(orderDate);

            OrderStatus orderStatus = (previousOrderStatus == OrderStatus.None || isInStock) 
                ? OrderStatus.Processing 
                : OrderStatus.OnHoldStockUnavailable;

            if (timeUntilEstimatedDelivery.Days < 0)
            {
                orderStatus = OrderStatus.Delayed;
            }

            if (isPriorityCustomer && isInStock)
            {
                orderStatus = OrderStatus.PrioritizedProcessing;
            }

            if (!isInStock)
            {
                if (updatedStockItems > 0)
                {
                    return RecalculateOrderStatus(
                        orderStatus,
                        orderDate, 
                        estimatedDeliveryDate, 
                        updatedStockItems, 
                        updatedStockItems, 
                        customerFeedbackScore,
                        shippingDelayResolved,
                        depth + 1);
                }
            }

            // Investigate delays for orders in processing for too long
            if (orderStatus == OrderStatus.Processing && timeSinceOrderPlaced.Days > 5)
            {
                orderStatus = OrderStatus.InvestigatingDelay;

                if (shippingDelayResolved)
                {
                    // Recursively call to re-evaluate status with potential delay resolution
                    return RecalculateOrderStatus(
                        orderStatus,
                        orderDate, 
                        estimatedDeliveryDate, 
                        itemsInStock,
                        updatedStockItems,
                        customerFeedbackScore,
                        shippingDelayResolved,
                        depth + 1);
                }
            }

            // Adjust for holiday season and express handling
            if (IsHolidaySeason())
            {
                orderStatus = OrderStatus.DelayedHolidaySeason;
            }

            if (customerFeedbackScore > 95 && orderStatus == OrderStatus.PrioritizedProcessing)
            {
                orderStatus = OrderStatus.ExpressHandling;
            }

            return orderStatus;
        }


        private bool IsHolidaySeason()
        {
            return DateTime.Now.Month == 12;
        }
    }
}


