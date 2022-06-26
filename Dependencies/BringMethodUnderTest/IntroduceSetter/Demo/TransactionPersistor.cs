using Dependencies.BringMethodUnderTest.IntroduceSetter.Demo;
using MongoDB.Driver.Core.Configuration;

namespace Dependencies.BringClassUnderTest.IntroduceSetter.Demo
{
    public class TransactionPersistor
    {
        private MongoDbConnector MongoDb { get; }

        private CommissionConfig _cconfig;

        public string ConnectionString { get; }

        public TransactionPersistor()
        {
            ConnectionString = AppSettings.ConnectionString;
        }

        public int Save(Transaction tx)
        {
            var dbTx = new MongoDbTransaction(tx.TransactionId, _cconfig.Commission)
            {
                Buyer = tx.Purchaser,
                Seller = tx.Merchant,

                ///
            };

            //MongoDb = new MongoDbConnector(ConnectionString);


            return MongoDb.SaveTx(dbTx);
        }
    }
}
