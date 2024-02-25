using System.Threading.Tasks;
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

        public async Task Pay()
        {
            await _payment.ProcessPayment(100, "destinationAccount", true);
        }
    }
}
