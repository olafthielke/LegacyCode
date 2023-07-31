using Xunit;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class BusinessWorkflowTests
    {
        [Fact]
        public void Bring_Class_Under_Test()
        {
            var workflow = new BusinessWorkflow();
        }
    }
}
