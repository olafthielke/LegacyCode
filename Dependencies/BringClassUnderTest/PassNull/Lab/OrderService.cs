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
    }
}
