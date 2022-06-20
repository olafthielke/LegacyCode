using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public class CustomerDetailsRetriever
    {
        private const string ConnectionString = "Data Source=(local);Initial Catalog=Customers;Integrated Security=true";

        public async Task<CustomerDetails> GetCustomerDetails(string customerNumber)
        {
            var details = new CustomerDetails();

            var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            // ...

            return details;
        }
    }
}
