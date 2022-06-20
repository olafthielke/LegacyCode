using System.Threading.Tasks;
using Xunit;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public class CustomerBuilderTests
    {
        [Fact]
        public async Task Bring_Method_GetCustomer_Under_Test()
        {
            var builder = new CustomerBuilder();
            await builder.BuildCustomer("123");
        }
    }
}
