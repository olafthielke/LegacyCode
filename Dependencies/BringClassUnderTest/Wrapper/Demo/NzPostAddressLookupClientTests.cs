using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Dependencies.BringClassUnderTest.Wrapper.Demo
{
    public class NzPostAddressLookupClientTests
    {
        [Fact]
        public void Bring_Class_Under_Test()
        {
            var mockHttpClient = new Mock<IHttpClient>();
            var lookup = new NzPostAddressLookupClient(mockHttpClient.Object);
        }
    }
}
