using System.Collections.Generic;

namespace TestWebApi.Models
{
    public class DbInvoice
    {
        public int Id { get; set; }
        public int No { get; set; }
        public decimal Total { get; set; }

        public List<DbInvoiceLine> Lines { get; set; }

        public bool Updateable { get; set; }
        public decimal GstAmount { get; set; }

        public bool GstApplies { get; set; }

        public decimal GstRate { get; set; }
    }
}
