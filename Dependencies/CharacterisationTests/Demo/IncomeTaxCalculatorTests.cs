using FluentAssertions;
using Xunit;

namespace Dependencies.CharacterisationTests.Demo
{
    public class IncomeTaxCalculatorTests
    {
        [Theory]
        [InlineData(10000, 20, false, 0, 485)]
        [InlineData(250000, 48, true, 3, 63244)]
        [InlineData(50000, 34, false, 1, 4480)]
        [InlineData(15000, 30, true, 2, 0)]
        [InlineData(150000, 30, true, 4, 36024)]
        [InlineData(500000, 18, false, 0, 149910)]
        [InlineData(1000000, 45, true, 2, 282740)]
        public void CalculateTax_Characterisation_Test(int income, int age, bool isMarried, int numberOfChildren, double taxAmount)
        {
            var calc = new IncomeTaxCalculator();
            
            var tax = calc.CalculateTax(income, age, isMarried, numberOfChildren);
            
            tax.Should().Be(taxAmount);
        }
    }
}
