using FluentAssertions;
using Xunit;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab
{
    public class RegularAccountTransactionValidatorTests
    {
        // These tests are not quite right, and won't work as they are. 
        // They demonstrate how to write tests for the first condition in the Validate method.
        // It's up to you to write tests for the other conditions, including the 

        // Note: The tests should tell 'the story of the code'.

        //[Fact]
        //public void Given_BankTransaction_Is_Null_When_Call_Validate_Then_Returns_False()
        //{
        //    var result = RegularAccountTransactionValidator.Validate(null, new BankAccount(), 0);
        //    result.Should().BeFalse();
        //}

        //[Fact]
        //public void Given_BankAccount_Is_Null_When_Call_Validate_Then_Returns_False()
        //{
        //    var result = RegularAccountTransactionValidator.Validate(new BankTransaction(), null, -1000);
        //    result.Should().BeFalse();
        //}

        //[Theory]
        //[InlineData("123", "456")]
        //[InlineData("123456", "987654")]
        //[InlineData("ABC123", "DEF987")]
        //public void Given_Different_AccountNumbers_When_Call_Validate_Then_Returns_False(string transactionAccountNumber, string accountNumber)
        //{
        //    var tx = new BankTransaction { AccountNumber = transactionAccountNumber };
        //    var acc = new BankAccount { AccountNumber = accountNumber };
        //    var result = RegularAccountTransactionValidator.Validate(tx, acc, -1000);
        //    result.Should().BeFalse();
        //}

        //// From here using same account numbers without needing to spell it out.
        
        //// Hint: You need to test for positive and negative conditions!
        //// As in Validate passes and fails.
        
        
        //public void Given_Transaction_Overdraws_When_Call_Validate_Then_Returns_False()
        //{
        //    // TODO: Write the test.
        //}

        //public void Given_Transaction_Is_Allowed_When_Call_Validate_Then_Returns_True()
        //{
        //    // TODO: Write the test.
        //}
    }
}
