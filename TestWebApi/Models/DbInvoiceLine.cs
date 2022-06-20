namespace TestWebApi.Models
{
    public class DbInvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceNumber { get; set; }
        public int ProductId { get; set; }
        public int LineNumber { get; set; }
        public decimal Subtotal { get; set; }

        public int Quantity { get; set; }
        public string ProductName { get; set; }

        public string SKU { get; set; }
    }
}
