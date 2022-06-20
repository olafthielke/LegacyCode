namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo
{
    public class AnalyticsService
    {
        public IAnalyticsLogger Logger { get; set; }


        public AnalyticsService()
        {
            Logger = new AnalyticsLogger();

            Logger.Log("Analytics service initialised.", 3);
        }
    }
}
