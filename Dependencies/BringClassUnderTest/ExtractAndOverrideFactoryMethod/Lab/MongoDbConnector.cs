using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public class MongoDbConnector
    {
        public MongoDbConnector(string connString)
        {
            MongoClient dbClient = new MongoClient(connString);

            var dbList = dbClient.ListDatabases().ToList();

            // ... 
        }

        public int SaveTx(MongoDbTransaction tx)
        {
            // ...

            return (int)SuccessCode.Success;
        }
    }
}
