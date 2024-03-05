using System;
using System.Data.SqlClient;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab
{
    public class SqlCustomerReader
    {
        public SqlDataReader SqlReader { get; set; }

        public SqlCustomerReader(SqlDataReader sqlReader)
        {
            SqlReader = sqlReader ?? throw new ArgumentNullException(nameof(sqlReader));
        }

        public Lab_Hard.DbCustomer ReadCustomer()
        {
            var value = SqlReader["Guid"];
            var idString = value.ToString();
            var guid = new Guid(idString);
            value = SqlReader["FirstName"];

            var fnString = value.ToString();
            var lastName = SqlReader["LastName"];
            var lnStr = lastName.ToString();

            var emailAddress = SqlReader["EmailAddress"].ToString();

            var client = new Lab_Hard.DbCustomer(lnStr, fnString)
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
