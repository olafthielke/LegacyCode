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
