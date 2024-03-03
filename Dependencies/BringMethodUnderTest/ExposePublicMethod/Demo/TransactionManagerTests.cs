using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Dependencies.BringMethodUnderTest.ExposePublicMethod.Demo
{
    public class TransactionManagerTests
    {
        [Fact]
        public async Task If_BankTransaction_Is_Missing_When_Call_Validate_Then_Throw_Exception()
        {
            //var mgr = new TransactionManager("connectionString");
            //var validate = () => mgr.Validate(null);
            //await validate.Should().ThrowAsync<Exception>().WithMessage("Transaction is required.");
        }
        
        // TODO: Write test(s) for no description/particulars.
        
        // TODO: Write test(s) for the new condition, invalid transaction amount.
    }
}
