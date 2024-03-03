using FluentAssertions;
using Xunit;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab
{
    public class RegularAccountTransactionValidatorTests
    {
        // These tests are not quite right, and won't work as they are. 
        // They demonstrate how to write tests for the first condition in the Validate method.
        // It's up to you to write tests for the other conditions, including the 
        
        
        //[Fact]
        //public void Given_BankTransaction_Is_Null_When_Call_Validate_Then_Return_False()
        //{
        //    var result = RegularAccountTransactionValidator.Validate(null, new BankAccount());
        //    result.Should().BeFalse();
        //}

        //[Fact]
        //public void Given_BankAccount_Is_Null_When_Call_Validate_Then_Return_False()
        //{
        //    var result = RegularAccountTransactionValidator.Validate(new BankTransaction(), null);
        //    result.Should().BeFalse();
        //}
    }
}
