using System.Collections.Generic;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public interface ISqlEmployeeReader
    {
        List<Employee> GetAllEmployees();
    }
}
