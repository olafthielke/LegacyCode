using System.Collections.Generic;
using Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab;
using Dependencies.BringClassUnderTest.PassNull.Demo;
using Microsoft.AspNetCore.Mvc;
using Employee = Dependencies.BringClassUnderTest.PassNull.Demo.Employee;

namespace WebApi.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeePersistanceService _employeeSaveService;
        public EmployeeRetrievalService _employeeGetService;
        private EmployeeManager EmployeeManager { get; }
        private List<Employee> _employees;

        public int Payroll => CalcPayroll();

        public EmployeesController()
        {
            _employeeSaveService = new EmployeePersistanceService();

            _employeeGetService = new EmployeeRetrievalService();
            _employees = _employeeGetService.LoadEmployees();
        }


        public int CalcPayroll()
        {
            var employees = _employeeGetService.LoadEmployees();

            return EmployeeManager.CalcPayroll(employees);
        }
    }
}
