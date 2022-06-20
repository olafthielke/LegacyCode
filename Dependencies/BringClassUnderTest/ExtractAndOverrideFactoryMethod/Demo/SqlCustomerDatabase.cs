using System.Data.SqlClient;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Demo
{
    public class SqlCustomerDatabase
    {
        public SqlCustomerDatabase(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();

            // ..
        }
    }
}
