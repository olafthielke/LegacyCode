using System;
using log4net;

namespace Dependencies.BringMethodUnderTest.ExtractMethod.Demo
{
    public class Application
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Application));

        private ICustomerRepository Repository { get; }

        private LogLevel LogLevel { get; }

        public Application(ICustomerRepository repository, LogLevel logLevel = LogLevel.Debug)
        {
            Repository = repository;
            LogLevel = logLevel;
        }

        public Customer Register(CustomerData customerData)
        {
            if (customerData == null)
            {
                if (LogLevel == LogLevel.Debug)
                {
                    Logger.Debug("No customer data.");
                }
                else
                {
                    Logger.Error("No customer data.");
                }
                throw new Exception("No customer data.");
            }

            var error = customerData.Validate();
            if (error != null)
            {
                if (LogLevel == LogLevel.Debug)
                {
                    Logger.Debug(error);
                }
                else
                {
                    Logger.Error(error);
                }
                throw new Exception(error);
            }

            if (LogLevel == LogLevel.Debug)
            {
                Logger.Debug("Check whether customer already exists.");
            }
            else
            {
                Logger.Error("Check whether customer already exists.");
            }

            var existCust = Repository.GetCustomer(customerData.EmailAddress);
            if (existCust != null)
            {
                string msg = $"Customer with email address '{customerData.EmailAddress}' already exists.";

                if (LogLevel == LogLevel.Debug)
                {
                    Logger.Debug(msg);
                }
                else
                {
                    Logger.Error(msg);
                }
                throw new Exception($"Customer with email address '{customerData.EmailAddress}' already exists.");
            }

            if (LogLevel == LogLevel.Debug)
            {
                Logger.Debug("Convert data to customer.");
            }
            else
            {
                Logger.Error("Convert data to customer.");
            }
            var customer = Convert(customerData);

            if (LogLevel == LogLevel.Debug)
            {
                Logger.Debug("Convert data to customer.");
            }
            else
            {
                Logger.Error("Convert data to customer.");
            }


            if (LogLevel == LogLevel.Debug)
            {
                Logger.Debug("Save customer to database");
            }
            else
            {
                Logger.Error("Save customer to database");
            }
            Repository.SaveCustomer(customer);

            return customer;
        }


        private Customer Convert(CustomerData data)
        {
            return new Customer()
            {
                CustomerNumber = Guid.NewGuid().ToString(),
                FirstName = data.FirstName,
                LastName = data.LastName,
                EmailAddress = data.EmailAddress,
                PhoneNumber = data.PhoneNumber
            };
        }
    }
}
