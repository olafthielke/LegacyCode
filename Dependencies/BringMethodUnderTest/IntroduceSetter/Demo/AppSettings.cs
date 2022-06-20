using System.Configuration;

namespace Dependencies.BringClassUnderTest.IntroduceSetter.Demo
{
    public static class AppSettings
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["TransactionDatabase"].ConnectionString;
    }
}
