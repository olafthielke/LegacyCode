namespace Dependencies.BringMethodUnderTest.Exercises.Exercise1
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string email);

        void SaveCustomer(Customer customer);
    }
}
