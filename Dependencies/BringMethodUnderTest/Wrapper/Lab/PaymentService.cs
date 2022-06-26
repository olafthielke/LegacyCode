using System;
using System.Configuration;
using LegacyLibrary.PaymentGateway;

namespace Dependencies.BringMethodUnderTest.Wrapper.Lab
{
    public class PaymentService
    {
        public PayResult MakePayment(PaymentData paymentData)
        {
            if (paymentData.Amount <= 0)
                throw new Exception("Invalid payment amount!");

            var gatewayCreds = ConfigurationManager.AppSettings["PaymentGatewayCreds"];

            var creds = gatewayCreds.Split('|');

            var gateway = new LegacyPaymentGateway();

            var response = gateway.Pay(new Authorization()
            {
                AuthLevel = 2,
                Username = creds[0] ?? paymentData.Username,
                Password = creds[1] ?? paymentData.Password,
            },
                new Checkout()
                {
                    Amount = paymentData.Amount
                });

            if (!response.Success)
                throw new Exception("Payment failed.");

            return new PayResult()
            {
                Success = true,
                Error = null
            };
        }
    }
}
