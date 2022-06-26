using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Lab
{
    public class AustralianGstCalculatorTests
    {
        private static readonly Product Apple = new Product { Name = "Apple", UnitPrice = 0.35m };
        private static readonly Product Banana = new Product { Name = "Banana", UnitPrice = 0.75m };

        [Fact]
        public void Calc_Gst()
        {
            var calculator = new AustralianGstCalculator();
            var invoice = new Invoice
            {
                Lines = new List<InvoiceLine>()
                {
                    new InvoiceLine { Product = Apple, Quantity = 3 },
                    new InvoiceLine { Product = Banana, Quantity = 5 }
                }
            };

            var gstAmount = calculator.CalcGst(invoice);
            gstAmount.Should().Be(0.105m + 0.375m);
        }
    }
}
