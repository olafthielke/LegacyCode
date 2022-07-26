using System;
using System.Data.SqlClient;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Demo
{
    public class SqlCustomerReader
    {
        public SqlDataReader SqlReader { get; set; }

        public SqlCustomerReader(SqlDataReader sqlReader)
        {
            SqlReader = sqlReader ?? throw new ArgumentNullException(nameof(sqlReader));
        }

        public DbCustomer ReadCustomer()
        {
            var value = SqlReader["Guid"];
            var idString = value.ToString();
            var guid = new Guid(idString);
            value = SqlReader["FirstName"];

            var fnString = value.ToString();
            var lastName = SqlReader["LastName"];
            var lnStr = lastName.ToString();

            var emailAddress = SqlReader["EmailAddress"].ToString();

            var client = new DbCustomer(lnStr, fnString)
            {
                Id = guid,
                FirstName = fnString,
                LastName = lnStr,
                EmailAddress = emailAddress
            };

            return client;
        }
    }
}
