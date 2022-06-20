using Xunit;

namespace Dependencies.BringClassUnderTest.IntroduceSetter.Demo
{
    public class TransactionPersistorTests
    {
        [Fact]
        public void Bring_Class_Under_Test()
        {
            var persistor = new TransactionPersistor();
        }
    }
}
