using System.Collections.Generic;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class EmployeeRetrievalService
    {
        private ISqlEmployeeReader _sqlEmployeeReader;

        public EmployeeRetrievalService()
        {
            _sqlEmployeeReader = new SqlEmployeeReader();

            // ...
        }

        public List<Employee> LoadEmployees()
        {
            var employees = _sqlEmployeeReader.GetAllEmployees();

            // ... Do more work. Say, backfill employee payroll info from the HR database.

            return employees;
        }
    }
}
