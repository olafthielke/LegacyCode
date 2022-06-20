using Dependencies.BringClassUnderTest.ExtractInterface.Lab;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PaymentsController : Controller
    {

        public PaymentChannel _payment;


        public PaymentsController()
        {
            _payment = new PaymentChannel();

            // ...
        }
    }
}
