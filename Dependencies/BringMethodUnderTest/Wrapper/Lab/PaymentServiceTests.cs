using LegacyLibrary.PaymentGateway;
using Xunit;

namespace Dependencies.BringMethodUnderTest.Wrapper.Lab
{
    public class PaymentServiceTests
    {
        [Fact]
        public void Test_Payment()
        {
            var svc = new PaymentService();
            var data = new PaymentData()
            {
                Amount = 100,
                TaxAmount = 10,
                Username = "bob",
                Password = "password"
            };
            svc.MakePayment(data);
        }
    }
}
