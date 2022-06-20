using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public class MongoDbTransaction
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public decimal TotalAmount { get; set; }
        public string TransactionId { get; set; }
        public string AffiliateId { get; set; }
        public decimal Commission { get; set; }
        public string AffiliateName { get; set; }

        public MongoDbTransaction(Guid? id, int commissionPercent)
        {
            if (id == null)
                id = Guid.NewGuid();
            Commission *= (1 + commissionPercent);
        }
    }
}
