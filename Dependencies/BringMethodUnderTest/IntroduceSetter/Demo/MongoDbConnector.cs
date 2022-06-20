using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.IntroduceSetter.Demo
{
    public class MongoDbConnector
    {
        private string ConnectionString { get; }

        public MongoDbConnector(string connString)
        {
            ConnectionString = connString;
            // ... 
        }

        public int SaveTx(MongoDbTransaction tx)
        {
            MongoClient dbClient = new MongoClient(ConnectionString);

            var dbList = dbClient.ListDatabases().ToList();

            // ...

            return (int)SuccessCode.Success;
        }
    }
}
