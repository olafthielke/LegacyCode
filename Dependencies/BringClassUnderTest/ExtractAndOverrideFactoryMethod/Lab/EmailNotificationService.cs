using System.Net.Mail;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public class EmailNotificationService
    {
        public EmailNotificationService(EmailConfig emailConfig, MongoDbConnector mongoDb)
        {
            
        }

        public void Send(MailMessage email)
        {
            
        }
    }
}
