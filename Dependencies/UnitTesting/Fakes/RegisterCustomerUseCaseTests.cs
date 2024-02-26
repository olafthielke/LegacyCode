using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;

namespace Dependencies.UnitTesting.Fakes
{
    public class RegisterCustomerUseCaseTests
    {
        // DUMMY

        [Fact]
        public async Task Given_No_CustomerRegistration_When_Call_RegisterCustomer_Then_Throw_MissingCustomerRegistration()
        {
            // Arrange
            var useCase = new RegisterCustomerUseCase(
                null /* DUMMY */,
                null /* DUMMY */);

            // Act
            var register = () => useCase.RegisterCustomer(null);

            // Assert
            await register.Should().ThrowExactlyAsync<MissingCustomerRegistration>()
                .Where(x => x.Message == "Missing customer registration data.");
        }

        // ... More tests (not shown)

        // STUB

        [Fact]
        public async Task Given_Customer_Already_Exists_In_Repo_When_Call_RegisterCustomer_Then_Throw_DuplicateCustomerEmailAddress()
        {
            // Arrange
            var customer = new Customer(new Guid("235A4B1F-0D7F-4F7C-BAFE-1FA79DC80E3C"), "Fred", "Flintstone", "fred@flintstones.net");
            var stubRepository = new Mock<ICustomerRepository>();
            stubRepository.Setup(x => x.GetCustomer("fred@flintstones.net")).ReturnsAsync(customer);

            var useCase = new RegisterCustomerUseCase(
                stubRepository.Object /* STUB (GetCustomer) */,
                null /* DUMMY */);

            // Act
            var registration = new CustomerRegistration("Fred", "Flintstone", "fred@flintstones.net");
            var register = () => useCase.RegisterCustomer(registration);

            // Assert
            await register.Should().ThrowExactlyAsync<DuplicateCustomerEmailAddress>()
                    .Where(x => x.EmailAddress == customer.EmailAddress)
                    .Where(x => x.Message == $"The email address '{customer.EmailAddress}' already exists in the system.");
        }

        // ... More tests (not shown)

        // MOCK

        [Fact]
        public async Task Given_Successful_Customer_Registration_When_Call_RegisterCustomer_Then_Send_Customer_Welcome_Message()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(x => x.GetCustomer(It.IsAny<string>())).ReturnsAsync((Customer)null);

            var mockNotifier = new Mock<ICustomerNotifier>();

            var useCase = new RegisterCustomerUseCase(
                mockRepository.Object /* STUB (GetCustomer) & MOCK(SaveCustomer) */,
                mockNotifier.Object /* MOCK (SendWelcomeMessage) */);

            // Act
            var registration = new CustomerRegistration("Fred", "Flintstone", "fred@flintstones.net");
            var customer = await useCase.RegisterCustomer(registration);

            // Assert
            mockNotifier.Verify(x => x.SendWelcomeMessage(customer));
        }
    }
}