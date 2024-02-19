using System.Configuration;

namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Lab
{
    public sealed class NotifierSingleton
    {
        private NotifierSingleton() { }

        private static NotifierSingleton _instance = null;

        public static NotifierSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NotifierSingleton();
            }
            return _instance;
        }

        public Sender GetSender()
        {
            // Do some troublesome thing...

            var connString = ConfigurationManager.AppSettings["ConnectionString"];

            var database = new MongoDbConnector(connString);


            // ...

            return new Sender();
        }
    }
}
