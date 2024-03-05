using System;

namespace Dependencies.BringMethodUnderTest.ParameteriseMethod.Lab
{
    public class DbCustomer
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public DbCustomer()
        {

        }

        public DbCustomer(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
