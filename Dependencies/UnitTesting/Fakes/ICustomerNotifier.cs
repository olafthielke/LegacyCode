using System.Threading.Tasks;

namespace Dependencies.UnitTesting.Fakes
{
    public interface ICustomerNotifier
    {
        Task SendWelcomeMessage(Customer customer);
    }
}