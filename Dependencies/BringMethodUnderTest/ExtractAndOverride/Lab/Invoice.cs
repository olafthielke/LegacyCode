using System.Collections.Generic;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Lab
{
    public class Invoice
    {
        public List<InvoiceLine> Lines { get; set; } = new List<InvoiceLine>();
    }
}
