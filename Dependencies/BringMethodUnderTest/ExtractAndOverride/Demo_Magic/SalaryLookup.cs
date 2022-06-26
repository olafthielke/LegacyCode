using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo_Magic
{
    public static class SalaryLookup
    {
        public static DbSalaryDetails Lookup(string employeeNo)
        {
            DbSalaryDetails salary = null;

            const string connString = "Server=tcp:prod.database.windows.net,1433;Initial Catalog=Employees;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=10;";

            var conn = new SqlConnection(connString);
            conn.Open();

            // ...

            return salary;
        }
    }
}
