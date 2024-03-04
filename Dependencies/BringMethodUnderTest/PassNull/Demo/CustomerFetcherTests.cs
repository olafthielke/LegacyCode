using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace Dependencies.BringMethodUnderTest.PassNull.Demo
{
    public class CustomerFetcherTests
    {
        // Potential test cases:
        // 1. DetailsFetcher.FetchDetails() returns a null
        // 2. DetailsFetcher.FetchDetails() returns a valid CustomerDetails object
        //    and you get to do the conversion to Customer object. Yeah!
    }
}
