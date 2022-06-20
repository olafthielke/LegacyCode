using System;

namespace TestWebApi.Models
{
    public class BankTransaction
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Particulars { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
