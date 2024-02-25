using System.Threading.Tasks;
using Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo;
using Dependencies.BringClassUnderTest.PassNull.Lab;
using Dependencies.BringClassUnderTest.PrimitiviseParameter.Demo;
using Dependencies.BringClassUnderTest.PrimitiviseParameter.Lab;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDatabase CustomerDatabase { get; set; }
        private AnalyticsService AnalyticsService { get; set; }
        private CustomerOrderService CustomerOrderService { get; set; }
        private AddressLookupService AddressLookupService { get; set; }

        public CustomersController()
        {
            CustomerDatabase = new CustomerDatabase();
            AnalyticsService = new AnalyticsService();
            CustomerOrderService = new CustomerOrderService(7);

            var config = new ConnectionStringConfig
            {
                DatabasesConfig = new DatabasesConfig
                {
                    DatabaseConfig = new DatabaseConfig
                    {
                        ConnectionString = "Some Connection String"
                    }
                }
            };
            AddressLookupService = new AddressLookupService(config);
        }


        public async Task CreateCustomerOrder(string custEmail, Order order)
        {
            var dbCust = CustomerDatabase.GetCustomer(custEmail);

            var customer = new Customer()
            {
                Number = dbCust.Number,
                Name = dbCust.Name,
                Email = dbCust.EmailAddress
            };

            order.PostalAddress = await AddressLookupService.LookupAddress(customer.Address);


            CustomerOrderService.CreateCustomerOrder(customer, order);

            AnalyticsService.Log(order);
        }
    }
}
