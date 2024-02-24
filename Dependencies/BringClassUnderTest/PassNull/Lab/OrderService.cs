using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.PassNull.Lab
{
    public class OrderService
    {
        public MongoClient _dbClient;

        public OrderService(int config)
        {
            if (config == 0)
            {
                _dbClient = new MongoClient("Production Connection String");
            }
            else if (config == 2)
            {
                _dbClient = new MongoClient("Staging Connection String");
            }
            else
            {
                _dbClient = new MongoClient("Development Connection String");
            }
        }

        public int? Initialise()
        {
            var dbList = _dbClient.ListDatabases().ToList();

            // ...

            return -1;
        }

        public void Prepopulate()
        {
            // ...
        }

        public bool CheckAvailability(Order order)
        {
            // ...

            return true; 
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            // ...    
        }

        public void LogOrderAttempt(int orderId)
        {
            // ...
        }

        public ServiceResult CreateOrder(string customerId, Order order)
        {
            var result = new ServiceResult();
            
            // ...

            return result;
        }

        public void SendOrderConfirmationEmail(Customer customer, int orderId)
        {
            
        }

        public void QueueOrderForConfirmation(Customer customer, int orderId)
        {
            // ...
        }

        public bool LogError(string message)
        {
            // ...

            return true;
        }
    }
}
