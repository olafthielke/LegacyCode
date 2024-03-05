using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab
{
    public class TransactionManagerTests
    {
        [Fact]
        public async Task Validate_Missing_Transaction()
        {
            var mgr = new TransactionManager("conn string");
            Func<Task> validate = async () => await mgr.Validate(null);
            await validate.Should().ThrowExactlyAsync<Exception>().WithMessage("Transaction is required.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(" \t \n ")]
        public async Task Validate_Missing_Transaction_Description(string description)
        {
            var mgr = new TransactionManager("conn string");
            var tx = new BankTransaction { Description = description };
            Func<Task> validate = async () => await mgr.Validate(tx);
            await validate.Should().ThrowExactlyAsync<Exception>().WithMessage("Particulars is required.");
        }

        [Fact]
        public async Task Validate_Zero_Transaction_Amount()
        {
            var mgr = new TransactionManager("conn string");
            var tx = new BankTransaction { Description = "hello world!", TransactionAmount = 0 };
            Func<Task> validate = async () => await mgr.Validate(tx);
            await validate.Should().ThrowExactlyAsync<Exception>().WithMessage("0 is not a valid transaction amount.");
        }
    }
}
