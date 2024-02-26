using Xunit;

namespace Dependencies.UnitTesting.HowMuchTesting
{
    public class CustomerBuilderTests
    {
        [Fact]
        public void Test_BuildCustomer_Has_LoyaltyNumber()
        {
            // Arrange
            var customerData = new[] { "189347", "Fred", "Flintstone", "fred@flintstones.net", "375429" };
            var address = "123 Main St, Rockwell, Prehistory";

            // Act            
            var customer = CustomerBuilder.BuildCustomer(customerData, address);

            // Assert
            Assert.Equal(375429, customer.LoyaltyNumber);   // We're checking the LoyaltyNumber. OK.
                                                            // How can we do better?
        }

        
        
        
        
        [Fact]
        public void Test_BuildCustomer()
        {
            // Arrange
            var customerData = new[] { "189347", "Fred", "Flintstone", "fred@flintstones.net", "375429" };
            var address = "123 Main St, Rockwell, Prehistory";

            // Act
            var customer = CustomerBuilder.BuildCustomer(customerData, address);

            // Assert
            Assert.Equal(189347, customer.CustomerNumber);
            Assert.Equal("Fred", customer.FirstName);
            Assert.Equal("Flintstone", customer.LastName);
            Assert.Equal("fred@flintstones.net", customer.Email);
            Assert.Equal("123 Main St, Rockwell, Prehistory", customer.Address);
            Assert.Equal(375429, customer.LoyaltyNumber);   // Tests for entire customer object including LoyaltyNumber. Better!
                                                            // How can we do better?
        }





        [Theory]
        [InlineData("189347", "Fred", "Flintstone", "fred@flintstones.net", "375429", "123 Main St, Rockwell, Prehistory")]
        [InlineData("632909", "Barney", "Rubble", "barney.rubble@gmail.com", "100678", "456 Suburb Ave, Rockwell, Prehistory")]
        public void Test_BuildCustomer_Including_Data_Variety(
            string customerNumber, 
            string firstName, 
            string lastName, 
            string emailAddress, 
            string loyaltyNumber, 
            string address)
        {
            // Arrange
            var customerData = new[] { customerNumber, firstName, lastName, emailAddress, loyaltyNumber };

            // Act
            var customer = CustomerBuilder.BuildCustomer(customerData, address);

            // Assert
            Assert.Equal(int.Parse(customerNumber), customer.CustomerNumber);
            Assert.Equal(firstName, customer.FirstName);
            Assert.Equal(lastName, customer.LastName);
            Assert.Equal(emailAddress, customer.Email);
            Assert.Equal(address, customer.Address);
            Assert.Equal(int.Parse(loyaltyNumber), customer.LoyaltyNumber);     // Variation on test data. Great!!
                                                                                // How can we do better?
        }
    }
}
