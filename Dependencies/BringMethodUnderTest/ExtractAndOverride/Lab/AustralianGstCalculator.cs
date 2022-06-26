using System;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Lab
{
    public class AustralianGstCalculator
    {
        public decimal CalcGst(Invoice invoice)
        {
            decimal gstAmount = 0;

            // TODO: The line subtotal and GST amounts should be rounded to 2 decimal places
            // at the line level.
            foreach (var line in invoice.Lines)
            {
                var subtotal = line.Product.UnitPrice * line.Quantity;

                var gstRate = GstProductSelector.SelectGstRate(line.Product);
                if (gstRate == null)
                    throw new Exception($"Unable to look up applicable GST rate for product '{line.Product.Name}'");

                gstAmount += gstRate.Value * subtotal;
            }

            return gstAmount;
        }
    }
}
