using System.Threading.Tasks;

namespace Dependencies.UnitTesting.Fakes
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(string emailAddress);

        Task SaveCustomer(Customer customer);
    }
}
