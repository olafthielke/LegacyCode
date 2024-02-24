using Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo;
using Dependencies.BringClassUnderTest.PassNull.Lab;
using Dependencies.BringClassUnderTest.PrimitiviseParameter.Demo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents.SystemFunctions;

namespace WebApi.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDatabase CustomerDatabase { get; set; }
        private AnalyticsService AnalyticsService { get; set; }
        private CustomerOrderService CustomerOrderService { get; set; }

        public CustomersController()
        {
            CustomerDatabase = new CustomerDatabase();
            AnalyticsService = new AnalyticsService();
            CustomerOrderService = new CustomerOrderService(7);
        }


        public void CreateCustomerOrder(string custEmail, Order order)
        {
            var dbCust = CustomerDatabase.GetCustomer(custEmail);

            var customer = new Customer()
            {
                Number = dbCust.Number,
                Name = dbCust.Name,
                Email = dbCust.EmailAddress
            };
            
            CustomerOrderService.CreateCustomerOrder(customer, order);
        }
    }
}
