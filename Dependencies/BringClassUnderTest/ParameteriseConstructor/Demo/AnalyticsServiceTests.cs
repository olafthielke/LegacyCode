using Moq;
using Xunit;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo
{
    public class AnalyticsServiceTests
    {
        [Fact]
        public void Bring_Class_Under_Test()
        {
            var srv = new AnalyticsService();
        }
    }
}
