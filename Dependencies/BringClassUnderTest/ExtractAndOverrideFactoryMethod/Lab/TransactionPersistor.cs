namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public class TransactionPersistor
    {
        private MongoDbConnector MongoDb { get; }

        private CommissionConfig _cconfig;

        public TransactionPersistor()
        {
            MongoDb = new MongoDbConnector(AppSettings.ConnectionString);

            var commissionConfig = new CommissionConfig()
            {
                Commission = 20,    // 20%
                NetTax = false,
                ApplyImmediately = true
            };
            _cconfig = commissionConfig;
        }

        public int Save(Transaction tx)
        {
            var dbTx = new MongoDbTransaction(tx.TransactionId, _cconfig.Commission)
            {
                Buyer = tx.Purchaser,
                Seller = tx.Merchant,

                // ...
            };

            // ...

            return MongoDb.SaveTx(dbTx);
        }
    }
}
