using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class MongoDbConnector
    {
        private IMongoDatabase Db;
        public MongoDbConnector(string connString)
        {
            MongoClient dbClient = new MongoClient(connString);

            Db = dbClient.GetDatabase("EmployeeDB");

            // ... 
        }

        public Employee GetEmployee(int id)
        {
            return null;
        }
    }
}
