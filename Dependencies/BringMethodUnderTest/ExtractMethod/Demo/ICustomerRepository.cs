using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringMethodUnderTest.ExtractMethod.Demo
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(string email);

        void SaveCustomer(Customer customer);
    }
}
