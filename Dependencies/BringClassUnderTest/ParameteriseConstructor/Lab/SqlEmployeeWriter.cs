using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public class SqlEmployeeWriter : ISqlEmployeeWriter
    {
        public SqlEmployeeWriter()
        {
            const string connString = "Server=tcp:prod.database.windows.net,1433;Initial Catalog=Employees;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=10;";

            var conn = new SqlConnection(connString);
            conn.Open();

            // ...
        }

        public void Save(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
