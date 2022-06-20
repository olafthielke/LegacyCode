using Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo;
using Dependencies.BringClassUnderTest.PrimitiviseParameter.Demo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDatabase CustomerDatabase { get; set; }
        private AnalyticsService AnalyticsService { get; set; }

        public CustomersController()
        {
            CustomerDatabase = new CustomerDatabase();
            AnalyticsService = new AnalyticsService();
        }
    }
}
