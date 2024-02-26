namespace Dependencies.UnitTesting.Fakes
{
    public class DuplicateCustomerEmailAddress : ClientInputException
    {
        public string EmailAddress { get; }

        public DuplicateCustomerEmailAddress(string emailAddress)
            : base($"The email address '{emailAddress}' already exists in the system.")
        {
            EmailAddress = emailAddress;
        }
    }
}