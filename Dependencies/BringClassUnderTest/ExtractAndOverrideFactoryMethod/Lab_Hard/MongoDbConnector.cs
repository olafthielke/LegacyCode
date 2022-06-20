using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab_Hard
{
    public class MongoDbConnector
    {
        public static IMongoClient _client;        // Hint: Already an interface!
        private static IMongoDatabase _database;


        public MongoDbConnector(IOptions<MongoDbConnection> mongoDbConn)
        {
            if (_client == null)
            {
                Connect(mongoDbConn.Value.ConnectionString);
            }
        }

        private void Connect(string connectionString)
        {
            string dbName = connectionString.Substring(connectionString.LastIndexOf('/') + 1);

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);
        }


        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}