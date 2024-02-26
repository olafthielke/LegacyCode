namespace Dependencies.UnitTesting.Fakes
{
    public class MissingCustomerRegistration : ClientInputException
    {
        public MissingCustomerRegistration()
            : base("Missing customer registration data.")
        { }
    }
}