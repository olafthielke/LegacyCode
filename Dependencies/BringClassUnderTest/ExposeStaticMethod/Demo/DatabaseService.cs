using MongoDB.Bson;
using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo
{
    public class DatabaseManager
    {
        private IMongoDatabase Db;
        private IMongoCollection<Customer> _customerCollection;

        public DatabaseManager(string connString)
        {
            MongoClient dbClient = new MongoClient(connString);

            Db = dbClient.GetDatabase("CustomerDB");

            _customerCollection = Db.GetCollection<Customer>("customers");
        }


        public bool TestConnection()
        {
            return Db.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
        }
    }
}
