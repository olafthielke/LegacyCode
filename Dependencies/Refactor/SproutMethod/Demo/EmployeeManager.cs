using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Dependencies.Refactor.SproutMethod.Demo
{
    public class EmployeeManager
    {
        public int CalcPayroll()
        {
            // TODO: database.GetEmployees() may return duplicate employees
            // (on employee.Number), and these should be removed from the
            // payroll calculation (and all the other work).
            // We don't have time (!) to write unit tests to cover all of
            // CalcPayroll(), which would be preferable.
            // How can we still proceed in safety?

            int payroll = 0;

            var connSettings = ConfigurationManager.ConnectionStrings["HR_DB"];
            if (connSettings != null)
            {
                var connString = connSettings.ConnectionString;
                if (connString != null)
                {
                    var database = new MongoDbConnector(connString);
                    var employees = new List<Employee>(database.GetEmployees());



                    for (int i = 0; i < employees.Count; i++)
                    {
                        payroll += employees[i].Salary;

                        employees[i].Address = AddressLookup.LookupAddress(employees[i].LocationId);


                        // ...
                    }

                    // ...
                }

                // ...
            }

            return payroll;
        }


        public IList<Employee> GetUniqueEmployees(IEnumerable<Employee> employees)
        {
            var uniqueEmployees = new List<Employee>();
            foreach (var employee in employees)
            {
                var existEmployee = uniqueEmployees.SingleOrDefault(e => e.Number == employee.Number);
                if (existEmployee == null)
                    uniqueEmployees.Add(employee);
            }
            return uniqueEmployees;
        }
    }
}
