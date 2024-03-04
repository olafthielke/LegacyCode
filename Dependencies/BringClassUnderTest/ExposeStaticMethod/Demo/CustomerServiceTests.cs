using Xunit;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo
{
    public class CustomerServiceTests
    {
        // Note: The ValidateCustomerNumber() method is a misnomer: It validates the entire customer
        // rather than just the customer number!

        [Fact]
        public void If_Customer_Is_Null_When_Call_ValidateCustomerNumber_Then_Throw_Exception()
        {
            // Just write this single test for now.
            
        }
        
        // Stretch Goal: Write additional test(s), e.g. for valid customer, etc.
    }
}
