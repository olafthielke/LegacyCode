using System;
using System.Data.SqlClient;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Lab
{
    public class SqlEmployeeWriter : ISqlEmployeeWriter
    {
        private SqlConnection conn;
        
        public SqlEmployeeWriter()
        {
            const string connString = "Server=tcp:prod.database.windows.net,1433;Initial Catalog=Employees;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=10;";

            conn = new SqlConnection(connString);

            conn.Open();
        }

        public void Save(EmployeeModel emp)
        {
            // Assuming emp.Id determines if it's a new employee (Id == 0) or an update
            string sql = "";
            if (emp.Id == 0)
            {
                //sql = $"INSERT INTO Employees (Name, Department, Salary) VALUES ('{emp.Name}', '{emp.Department}', {emp.Salary})";
            }
            else
            {
                //sql = $"UPDATE Employees SET Name = '{emp.Name}', Department = '{emp.Department}', Salary = {emp.Salary} WHERE Id = {emp.Id}";
            }

            using (var cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw new Exception("Saving employee to DB failed!");
                }
            }
        }
    }
}