using System;
using System.Configuration;
using LegacyLibrary.PaymentGateway;

namespace Dependencies.BringMethodUnderTest.Wrapper.Lab
{
    public class PaymentService
    {
        // TODO: Wrap unit tests around MakePayment() to characterise the behaviour.
        // We don't want to break what it currently does.
        public PayResult MakePayment(PaymentData paymentData)
        {
            if (paymentData.Amount <= 0)
                throw new Exception("Invalid payment amount!");

            // This static call to ConfigurationManager.AppSettings is going to be trouble
            // but we know how to overcome this by now, right?
            var gatewayCreds = ConfigurationManager.AppSettings["PaymentGatewayCreds"];

            var creds = gatewayCreds.Split('|');

            // LegacyPaymentGateway is not our code and does not have a usable interface.  
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
