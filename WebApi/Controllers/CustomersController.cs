using System.Threading.Tasks;
using Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo;
using Dependencies.BringClassUnderTest.PassNull.Lab;
using Dependencies.BringClassUnderTest.PrimitiviseParameter.Demo;
using Dependencies.BringClassUnderTest.PrimitiviseParameter.Lab;
using Dependencies.BringClassUnderTest.Wrapper.Demo;
using Dependencies.BringMethodUnderTest.Wrapper.Demo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerDatabase CustomerDatabase { get; set; }
        private AnalyticsService AnalyticsService { get; set; }
        private CustomerOrderService CustomerOrderService { get; set; }
        private AddressLookupService AddressLookupService { get; set; }
        
        private NzPostAddressLookupClient NzPostAddressLookupClient { get; set; }


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
            NzPostAddressLookupClient = new NzPostAddressLookupClient();
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

            var billingAddress = await NzPostAddressLookupClient.LookupAddress(customer.Address);
        }
    }
}
