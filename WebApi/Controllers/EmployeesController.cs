using System.Collections.Generic;
using System.Linq;
using Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab;
using Dependencies.BringClassUnderTest.PassNull.Demo;
using Microsoft.AspNetCore.Mvc;
using Employee = Dependencies.BringClassUnderTest.PassNull.Demo.Employee;

namespace WebApi.Controllers
{
    public class EmployeesController : Controller
    {
        private const string connString = "mongodb://myUser:myPassword123@209.244.54.166:27017/myDatabase";
        
        public EmployeePersistanceService _employeeSaveService;
        public EmployeeRetrievalService _employeeGetService;
        private EmployeeManager EmployeeManager { get; } = new EmployeeManager(connString);
        private List<Employee> _employees;

        public int Payroll => CalcPayroll();

        public EmployeesController()
        {
            _employeeSaveService = new EmployeePersistanceService(AuditLevel.High);

            _employeeGetService = new EmployeeRetrievalService();
            _employees = _employeeGetService.LoadEmployees();
        }

        [HttpGet]
        public int CalcPayroll()
        {
            var employees = _employeeGetService.LoadEmployees();

            return EmployeeManager.CalcPayroll(employees);
        }

        [HttpPost]
        public int UpdateEmployee(int employeeId, int status)
        {
            EmployeeManager.UpdateEmployeeStatus(employeeId, status);

            var employee = _employees.SingleOrDefault(x => x.Id == employeeId);
            if (employee == null)
                return -1;

            var dbEmp = new EmployeeModel
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.Email,
                Salary = employee.Salary,
                Bonus = employee.Bonus,
                HolidayDays = employee.HolidayDays,
                OvertimeAllowanceExceeded = employee.OvertimeAllowanceExceeded,
                PaymentDate = DayOfTheWeek.Friday
            };
            
            _employeeSaveService.SaveEmployee(dbEmp);

            return 1;
        }
    }
}
