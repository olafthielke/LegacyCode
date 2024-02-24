using System;
using System.Collections.Generic;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class EmployeeManager
    {
        private readonly MongoDbConnector _database;

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
                payroll = payroll + employees[i].Salary + employees[i].Bonus;
            }

            return payroll;
        }

        public void UpdateEmployeeStatus(int employeeId, int status)
        {
            var employee = _database.GetEmployee(employeeId);

            if (employee != null)
            {
                if (status < 1 || status > 5)
                {
                    if (employee.DeptId == 3)
                    {
                        if (employee.Status == 2)
                        {
                            employee.Bonus = 1000;
                        }
                        else
                        {
                            employee.Bonus = 2500;
                        }
  
                        employee.Status = ++status;
                    }
                    else if (employee.DeptId == 1)
                    {
                        employee.Bonus = 5000;
                    }
                    else if (employee.DeptId == 11)
                    {
                        employee.Bonus = 1800;
                    }

                    employee.Status = status;
                    
                    _database.UpdateEmployee(employee);

                    _database.UpdateDepartmentStatus(employeeId, employee.DeptId, status);
                }
                else
                {
                    throw new Exception($"{status} is not a valid employee status.");
                }
            }
            else
            {
                throw new Exception($"Employee with ID {employeeId} not found.");
            }
        }
    }
}
