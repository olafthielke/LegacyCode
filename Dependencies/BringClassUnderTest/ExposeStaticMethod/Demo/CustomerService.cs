using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo
{
    public class CustomerService
    {
        public CustomerService()
        {
            // Dependencies and conditions that make instantiation in test harness difficult.

            if (!GlobalConfig.Instance.IsServiceEnabled)
            {
                throw new InvalidOperationException("Service is not enabled in GlobalConfig.");
            }

            var databaseService = new Lab.DatabaseManager(GlobalConfig.Instance.ConnString);
            if (!databaseService.TestConnection())
            {
                throw new InvalidOperationException("Cannot establish a database connection.");
            }

            var requiredSetting = Environment.GetEnvironmentVariable("REQUIRED_SETTING");
            if (string.IsNullOrEmpty(requiredSetting))
            {
                throw new InvalidOperationException("Required environment variable is not set.");
            }

            if (DateTime.Now.Millisecond % 2 == 0)
            {
                throw new InvalidOperationException("Cannot instantiate on even milliseconds.");
            }

            if (!File.Exists("/path/to/specific/config.file"))
            {
                throw new InvalidOperationException("Required configuration file is missing.");
            }
        }

        public void ValidateCustomerNumber(Customer customer)
        {
            if (customer != null)
            {
                // Currently, customer number must be 8 digits long and only contain numbers.
                // TODO: Change this to also allow for a 'C' prefix for customers from the old system.
                
                Regex regex = new Regex("^[0-9]{8}$", RegexOptions.IgnoreCase);
                Match match = regex.Match(customer.Number);

                if (match.Success &&
                    (customer.Category == CustomerCategory.REG ||
                     customer.Category == CustomerCategory.LOC) &&
                    customer.ManualCheckDone &&
                    !customer.CreatedByAdmin)
                {
                    return; // Valid customer.
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
