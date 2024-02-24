using System.Text.Json;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo
{
    public class AnalyticsService
    {
        public AnalyticsLogger Logger { get; set; }


        public AnalyticsService()
        {
            Logger = new AnalyticsLogger();

            Logger.Log("Analytics service initialised.", 3);
        }


        public void Log(object obj)
        {
            string json = JsonSerializer.Serialize(obj);

            Logger.Log(json, 1); // TODO: Change the log severity from 1 to 2.
        }
    }
}
