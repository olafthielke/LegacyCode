using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dependencies.BringClassUnderTest.ExtractInterface.Lab
{
    public  class PaymentChannel
    {
        private MoneyTransfer _transfer;
        
        public PaymentChannel()
        {
            _transfer = new MoneyTransfer();

            _transfer.ConfigurePayPal(true, 5, "PENDING").Wait();   // 3 means same-day payment.

            // ...
        }


        /// <summary>
        /// Processes payments using a legacy set of rules and configurations.
        /// </summary>
        /// <param name="amount">The amount to be transferred.</param>
        /// <param name="destination">The destination account identifier.</param>
        /// <param name="useExpedited">If true, attempts to use an expedited transfer method.</param>
        public async Task ProcessPayment(decimal amount, string destination, bool useExpedited)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new Exception("Invalid payment amount.");
                }

                // For amounts over 1000, always use expedited unless explicitly stated not to
                if (amount > 1000 && !useExpedited)
                {
                    useExpedited = true;
                }

                var paymentResult = await _transfer.InitiateTransfer(amount, destination, useExpedited);

                if (!paymentResult.IsSuccess)
                {
                    // TODO: If paymentResult.ErrorCode is "SERVER ERROR" then throw an exception "A server error occurred."

                    if (paymentResult.ErrorCode == "TIMEOUT" || paymentResult.ErrorCode == "BUSY")
                    {
                        paymentResult = await _transfer.InitiateTransfer(amount, destination, useExpedited);
                    }
                }

                if (paymentResult.IsSuccess)
                {
                    Log($"Payment of {amount} to {destination} processed successfully.");
                }
                else
                {
                    Log($"Failed to process payment after retry. Error: {paymentResult.ErrorCode}");
                }
            }
            catch (Exception ex)
            {
                // Legacy systems often have broad exception catches
                Log($"An exception occurred during payment processing: {ex.Message}");
                // Depending on legacy handling, might need to rethrow, swallow, or perform specific actions based on exception type
            }
        }


        private void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }


    public enum Currency
    {
        AUD,
        EUR,
        GBP,
        NZD,
        USD,
        // ...
    }
}
