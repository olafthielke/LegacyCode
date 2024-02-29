using System.Configuration;
using System.Net.Mail;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public class TransactionPersistor
    {
        private MongoDbConnector MongoDb { get; }

        private CommissionConfig _cconfig;

        private readonly EmailNotificationService _notificationService;
        
        public TransactionPersistor()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];
            MongoDb = new MongoDbConnector(StaticUtilityClass.DecryptConnectionString(connectionString));

            _notificationService = new EmailNotificationService(StaticUtilityClass.GetEmailConfig(), MongoDb);

            
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
                
                // ..
            };

            // ...

            var email = new MailMessage()
            {
                //
            };

            // ..

            var res =  MongoDb.SaveTx(dbTx);


            // ..


            _notificationService.Send(email);

            return res;
        }
    }
}
