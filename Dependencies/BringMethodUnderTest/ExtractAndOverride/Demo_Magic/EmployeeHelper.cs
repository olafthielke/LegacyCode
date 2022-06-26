using System.Collections.Generic;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo_Magic
{
    public class EmployeeHelper
    {
        private IEmployeeDatabase _database;

        public EmployeeHelper(IEmployeeDatabase database)
        {
            _database = database;
        }

        public IReadOnlyCollection<Employee> GetEmployeesWithDetails(string employeeNumbersString)
        {
            var employeeNumbers = employeeNumbersString.Split(",");

            var employees = new List<Employee>();

            foreach (var employeeNo in employeeNumbers)
            {
                if (string.IsNullOrWhiteSpace(employeeNo))
                    continue;

                var dbEmployee = _database.GetEmployee(employeeNo);
                if (dbEmployee == null)
                {
                    var employee = new Employee()
                    {
                        Name = "NOT FOUND",
                        Status = EmployeeStatus.Inactive,
                        EmployeeNumber = "",
                        Type = EmploymentType.None
                    };

                    employees.Add(employee);
                }
                else
                {
                    // TODO: We want to ensure that we are adding only ACTIVE employees
                    // to our employees list!

                    employees.Add(new Employee
                    {
                        Name = dbEmployee.FirstName + " " + dbEmployee.LastName,
                        Status = (EmployeeStatus)dbEmployee.Status,
                        EmployeeNumber = dbEmployee.EmployeeNumber,
                        Type = (EmploymentType)dbEmployee.EmploymentType
                    });
                }
            }

            // NOTE: For the sake of the changes we are trying to make, we don't need the salary details.
            // So why must we break the dependencies in this loop?
            foreach (var employee in employees)
            {
                // A lot of hard to remove dependencies in here that we're not interested in right now.
                // E.g. Breaking the dependency on the static EmployeeSalaryLookup.Lookup call.

                var salary = SalaryLookup.Lookup(employee.EmployeeNumber);

                // Do we even need to deal with all this if we're not interested in this behaviour
                // with regards to the changes we are planning to make.

                // ...
            }

            return employees;
        }
    }
}
