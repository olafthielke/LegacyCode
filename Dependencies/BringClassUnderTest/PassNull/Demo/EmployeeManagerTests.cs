using Xunit;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class EmployeeManagerTests
    {
        [Fact]
        public void Bring_Class_Under_Test()
        {
            // TODO: Bring class under test
            var mgr = new EmployeeManager(null, false);
        }

        [Fact]
        public void UpdateEmployeeStatus_When_Status_Is_6_Then_Update_Status()
        {
            var mgr = new EmployeeManager(null);
            mgr.UpdateEmployeeStatus(1, 6);
        }
    }
}
