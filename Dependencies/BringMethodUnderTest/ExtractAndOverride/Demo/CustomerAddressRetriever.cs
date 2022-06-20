﻿using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.ExtractAndOverride.Demo
{
    public static class CustomerAddressRetriever
    {
        public static async Task<Address> GetAddress(string customerNumber, string addressType)
        {
            var address = new Address();

            var connString = "Data Source=(local);Initial Catalog=Customers;Integrated Security=true";
            var connection = new SqlConnection(connString);
            await connection.OpenAsync();

            // ...

            return address;
        }
    }
}
