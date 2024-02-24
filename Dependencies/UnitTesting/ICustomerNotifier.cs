using System.Threading.Tasks;

namespace Dependencies.UnitTesting
{
    public interface ICustomerNotifier
    {
        Task SendWelcomeMessage(Customer customer);
    }
}