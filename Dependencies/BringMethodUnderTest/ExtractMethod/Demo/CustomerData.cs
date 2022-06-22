namespace Dependencies.BringMethodUnderTest.ExtractMethod.Demo
{
    public class CustomerData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }


        public string Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                return "No customer first name.";

            if (string.IsNullOrWhiteSpace(LastName))
                return "No customer last name.";

            if (string.IsNullOrWhiteSpace(EmailAddress))
                return "No customer email address.";

            return null;
        }
    }
}
