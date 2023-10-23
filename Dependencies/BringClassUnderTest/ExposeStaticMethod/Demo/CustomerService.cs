using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo
{
    public class CustomerService
    {
        public CustomerService()
        {
            // NOTE: Assume that this class is very difficult to get under test,
            // maybe because it has many concrete instantiations of other
            // services.

            // ...

            // Similate the inability to call create an instance of this class by
            // throwing an exception:
            throw new InvalidOperationException();
        }

        public void ValidateCustomerNumber(Customer customer)
        {
            if (customer != null)
            {
                Regex regex = new Regex("^C[0-9]{8}$", RegexOptions.IgnoreCase);
                Match match = regex.Match(customer.Number);

                if (match.Success &&
                    (customer.Category == CustomerCategory.REG ||
                     customer.Category == CustomerCategory.LOC) &&
                    customer.ManualCheckDone &&
                    !customer.CreatedByAdmin)
                {
                    return; 
                }
                else
                {
                    throw new Exception("Not a valid customer.");
                }
            }

            throw new ArgumentNullException("client");
        }
    }
}
