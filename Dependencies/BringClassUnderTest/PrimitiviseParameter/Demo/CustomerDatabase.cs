using System.Configuration;
using Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo;

namespace Dependencies.BringClassUnderTest.PrimitiviseParameter.Demo
{
    public class CustomerDatabase
    {
        private SqlCustomerDb _sqlDb;

        public CustomerDatabase()
        {
            var connString = ConfigurationManager.AppSettings["ConnectionStrings"];
            var connStrings = connString.Split('-');

            _sqlDb = new SqlCustomerDb
            {
                ConnectionString = connStrings[0]
            };

            var conn = _sqlDb.Connect();

            // ...
        }


        public Customer GetCustomer(string emailAddress)
        {
            var customer = _sqlDb.GetCustomer(emailAddress);

            // ...

            return customer;
        }
    }
}
