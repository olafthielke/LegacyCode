namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public static class AppConfig
    {
        public static decimal GetCorrelationSensitivity()
        {
            return 1.33m;    // dummy value
        }

        public static string GetConnectionString()
        {
            return "connection string";    // dummy value
        }
    }
}
