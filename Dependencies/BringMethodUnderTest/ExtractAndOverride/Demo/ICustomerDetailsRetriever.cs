using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public interface ICustomerDetailsRetriever
    {
        Task<CustomerDetails> GetCustomerDetails(string customerNumber);
    }
}
