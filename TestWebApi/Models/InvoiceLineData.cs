namespace TestWebApi.Models
{
    public class InvoiceLineData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSKU { get; set; }
        public int Quantity { get; set; }
    }
}
