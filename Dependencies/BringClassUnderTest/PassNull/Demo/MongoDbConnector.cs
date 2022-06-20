using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class MongoDbConnector
    {
        public MongoDbConnector(string connString)
        {
            MongoClient dbClient = new MongoClient(connString);

            var dbList = dbClient.ListDatabases().ToList();

            // ... 
        }
    }
}
