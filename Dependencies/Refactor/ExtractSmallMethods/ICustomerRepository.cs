namespace Dependencies.Refactor.ExtractSmallMethods
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string email);

        void SaveCustomer(Customer customer);
    }
}
