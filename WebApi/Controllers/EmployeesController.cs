using Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeePersistanceService _employeeSaveService;


        public EmployeesController()
        {
            _employeeSaveService = new EmployeePersistanceService();
        }
    }
}
