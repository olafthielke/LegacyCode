using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dependencies.BringClassUnderTest.PassNull.Demo
{
    public class SqlEmployeeReader : ISqlEmployeeReader
    {
        public SqlEmployeeReader()
        {
            const string connString = "Server=tcp:prod.database.windows.net,1433;Initial Catalog=Employees;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=10;";

            var conn = new SqlConnection(connString);
            conn.Open();

            // ...
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            // ... Gets the employees from the MongoDB database.

            return employees;
        }
    }
}
