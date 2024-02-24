namespace Dependencies.UnitTesting
{
    public class MissingCustomerRegistration : ClientInputException
    {
        public MissingCustomerRegistration()
            : base("Missing customer registration data.")
        { }
    }
}