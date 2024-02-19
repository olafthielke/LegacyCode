using System.Configuration;

namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Lab
{
    public class Sender
    {
        public void Send(Notification notification)
        {
            var connString = ConfigurationManager.AppSettings["ConnectionString"];

            var database = new MongoDbConnector(connString);
        }
    }
}
