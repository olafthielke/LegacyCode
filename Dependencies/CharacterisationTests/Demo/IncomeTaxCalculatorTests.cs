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
        public void CalculateTax_Characterisation_Test(int income, int age, bool isMarried, int numberOfChildren, double taxAmount)
        {
            var calc = new IncomeTaxCalculator();
            var tax = calc.CalculateTax(income, age, isMarried, numberOfChildren);
            tax.Should().Be(taxAmount);
        }
    }
}
