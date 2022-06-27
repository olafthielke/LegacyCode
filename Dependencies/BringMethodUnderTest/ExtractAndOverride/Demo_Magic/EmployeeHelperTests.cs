using Xunit;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo_Magic
{
    public class EmployeeHelperTests
    {
        [Fact]
        public void Test_GetEmployeesWithDetails()
        {
            var helper = new EmployeeHelper(null);
            helper.GetEmployeesWithDetails("123456");
        }
    }
}
