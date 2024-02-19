using System.Configuration;

namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Demo
{
    public sealed class RouteRetriever
    {
        private RouteRetriever() { }

        private static RouteRetriever _instance = null;

        public static RouteRetriever GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RouteRetriever();
            }
            return _instance;
        }

        public Dispatcher GetDispatcher()
        {
            // Do some troublesome thing...
            var connString = ConfigurationManager.AppSettings["ConnectionStrings"];
            var connStrings = connString.Split(',');



            return new Dispatcher();
        }
    }
}
