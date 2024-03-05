using System.Configuration;
using System.Data.SqlClient;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab_Hard
{
    public class CustomerLookup
    {
        public static DbCustomer LookupCustomer(string customerId)
        {
            var connString = ConfigurationManager.ConnectionStrings["CustomerDatabase"].ConnectionString;

            DbCustomer customer = null;
            
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                // Define the command
                using (var command = new SqlCommand($"SELECT Id, FirstName, LastName, Email FROM Customers WHERE Id = {customerId}", connection))
                {
                    // Execute the command and process the results
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new DbCustomer
                            {
                                Id = reader.GetGuid(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                EmailAddress = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return customer;
        }
    }
}
