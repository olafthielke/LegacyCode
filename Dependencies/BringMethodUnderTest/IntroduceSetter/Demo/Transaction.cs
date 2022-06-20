using System;

namespace Dependencies.BringClassUnderTest.IntroduceSetter.Demo
{
    public class Transaction
    {
        public string Merchant { get; set; }
        public string Purchaser { get; set; }
        public decimal Amount { get; set; }
        public Guid? TransactionId { get; set; }
        public string AffiliateId { get; set; }
        public decimal CommissionAmount { get; set; }
        public string AffiliateName { get; set; }
    }
}
