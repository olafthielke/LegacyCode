using System.Data.SqlClient;
using Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo;

namespace Dependencies.BringClassUnderTest.PrimitiviseParameter.Demo
{
    public class SqlCustomerDb
    {
        public string ConnectionString { get; set; }

        public SqlConnection Connect()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            // ..

            return conn;
        }

        public Customer GetCustomer(string emailAddress)
        {
            Customer customer = null;
            // Try and get customer from SQL database.

            // ...

            return customer;
        }
    }
}
