using System.Collections.Generic;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class EmployeeManager
    {
        private MongoDbConnector _database;

        public EmployeeManager(string connString, bool store = true)
        {
            if (store)
            {
                _database = new MongoDbConnector(connString);
            }
        }


        public int CalcPayroll(List<Employee> employees)
        {
            int payroll = 0;

            for (int i = 0; i < employees.Count; i++)
            {
                payroll = payroll + employees[i].Salary;
            }

            return payroll;
        }

        public void UpdateEmployeeStatus(int employeeId, int status)
        {
            // This is a method using _database
            var employee = _database.GetEmployee(employeeId);

            // ...
        }
    }
}
