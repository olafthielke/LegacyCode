using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services;

namespace TestWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly string _connectionString = "Server=.;Database=Components;Trusted_Connection=True;";


        [HttpGet]
        public async Task<IEnumerable<DbCustomer>> GetAll()
        {
            var customers = new List<DbCustomer>();

            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var cmd = new SqlCommand($"SELECT * FROM [dbo].[Customers]", connection);

            var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read() == true)
            {
                var value = reader["Guid"];
                var idString = value.ToString();
                var guid = new Guid(idString);
                value = reader["FirstName"];

                var fnString = value.ToString();
                var lastName = reader["LastName"];
                var lnStr = lastName.ToString();

                var email = reader["EmailAddress"].ToString();

                var client = new DbCustomer(lnStr, fnString)
                {
                    Id = guid,
                    FirstName = fnString,
                    LastName = lnStr,
                    EmailAddress = email
                };


                customers.Add(client);

            }

            connection.Close();

            return customers;
        }

        [HttpPost]
        public async Task<DbCustomer> Register(DbCustomer customer)
        {
            var email = "";

            if (customer == null)
                throw new ArgumentNullException("customer");


            if (string.IsNullOrWhiteSpace(customer.FirstName))
                throw new Exception("Missing first name.");
            //if (string.IsNullOrWhiteSpace(customer.MiddleName))
            //    throw new Exception("Missing middle name.");
            if (string.IsNullOrWhiteSpace(customer.LastName))
                throw new Exception("Missing last name.");

            if (string.IsNullOrWhiteSpace(customer.EmailAddress))
                throw new Exception("Missing email address.");
            email = customer.EmailAddress;

            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sqlcmd = new SqlCommand($"SELECT * FROM [dbo].[Customers] WHERE [EmailAddress] = '{email}'", connection);

            var reader = await sqlcmd.ExecuteReaderAsync();

            var sqlReader = new SqlCustomerReader(reader);
            DbCustomer client = null;
            while (reader.Read() != false)
            {

                client = sqlReader.ReadCustomer();

            }

            connection.Close();


            if (client != null)
                throw new ApplicationException($"The email address '{client.EmailAddress}' already exists in the system.");
            customer.Id = Guid.NewGuid();


            connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();


            var savecmd = new SqlCommand($"INSERT INTO [dbo].[Customers] ([Guid], [FirstName], [LastName], [EmailAddress]) VALUES ('{customer.Id}', '{customer.FirstName}', '{customer.LastName}', '{customer.EmailAddress}')", connection);


            await savecmd.ExecuteNonQueryAsync();

            connection.Close();


            return customer;
        }
    }
}
