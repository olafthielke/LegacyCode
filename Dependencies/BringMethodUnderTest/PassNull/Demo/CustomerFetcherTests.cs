using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace Dependencies.BringMethodUnderTest.PassNull.Demo
{
    public class CustomerFetcherTests
    {
        [Theory]
        [InlineData("12345678")]
        [InlineData("98576")]
        [InlineData("3453123")]
        [InlineData("645477")]
        public async Task Given_CustomerNumber_Does_Not_Start_With_C_When_Call_FetchCustomer_Then_Do_Not_Alter_CustomerNumber(string customerNumber)
        {
            var mockDetailsFetcher = new Mock<ICustomerDetailsFetcher>();
            mockDetailsFetcher.Setup(m => m.FetchDetails(It.IsAny<string>()))
                              .ReturnsAsync(new CustomerDetails()
                              {
                                  FirstName = "Fred",
                                  LastName = "Flintstone",
                                  Birthdate = "2000-05-24",
                                  CustomerId = customerNumber
                              });
            var fetcher = new CustomerFetcher(mockDetailsFetcher.Object);
            var customer = await fetcher.FetchCustomer(customerNumber, false);
            customer.CustomerNumber.Should().Be(customerNumber);
        }


        [Theory]
        [InlineData("C12345678")]
        [InlineData("C98576")]
        [InlineData("C3453123")]
        [InlineData("C123897")]
        public async Task Given_CustomerNumber_Does_Start_With_C_When_Call_FetchCustomer_Then_Strip_Off_C(string customerNumber)
        {
            var mockDetailsFetcher = new Mock<ICustomerDetailsFetcher>();
            mockDetailsFetcher.Setup(m => m.FetchDetails(It.IsAny<string>()))
                .ReturnsAsync(new CustomerDetails()
                {
                    FirstName = "Fred",
                    LastName = "Flintstone",
                    Birthdate = "2000-05-24",
                    CustomerId = customerNumber
                });
            var fetcher = new CustomerFetcher(mockDetailsFetcher.Object);
            var customer = await fetcher.FetchCustomer(customerNumber, false);
            customer.CustomerNumber.Should().Be(customerNumber.Substring(1));
        }
    }
}
