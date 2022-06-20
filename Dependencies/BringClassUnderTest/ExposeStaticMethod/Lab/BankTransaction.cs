using System;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab
{
    public class BankTransaction
    {
        public string AccountNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Description { get; set; }
        public string Type => TransactionAmount > 0 ? "CREDIT" : "DEBIT";
        public DateTime? TransactionDate { get; set; }
    }
}
