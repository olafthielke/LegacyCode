using System;
using System.Configuration;
using System.IO;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab
{
    public class RegularAccountTransactionValidator
    {
        private decimal _overdraftLimit;
        private decimal _maximumDepositAmount;

        public RegularAccountTransactionValidator()
        {
            // Dependencies and conditions that make instantiation in test harness difficult.

            var limitsString = ConfigurationManager.AppSettings["RegularAccountLimits"];
            var limits = limitsString.Split('|');

            _overdraftLimit = Convert.ToDecimal(limits[0]);
            _maximumDepositAmount = Convert.ToDecimal(limits[1]);


            if (!GlobalConfig.Instance.IsServiceEnabled)
            {
                throw new InvalidOperationException("Service is not enabled in GlobalConfig.");
            }

            var databaseService = new DatabaseManager(GlobalConfig.Instance.ConnString);
            if (!databaseService.TestConnection())
            {
                throw new InvalidOperationException("Cannot establish a database connection.");
            }

            var requiredSetting = Environment.GetEnvironmentVariable("SETTINGS_REQUIRED");
            if (string.IsNullOrEmpty(requiredSetting))
            {
                throw new InvalidOperationException("Required environment variable is not set.");
            }

            if (!File.Exists("/path/to/specific/config.file"))
            {
                throw new InvalidOperationException("Required configuration file is missing.");
            }
        }
        

        public bool Validate(BankTransaction tx, BankAccount acc)
        {
            if (tx == null || acc == null)
                return false;

            if (tx.AccountNumber != acc.AccountNumber)
                return false;

            // TODO: Fix bug in the following line.
            // Process like this:
            // 1. First, write tests to cover the existing condition.
            // 2. Then make changes to the tests that fix the bug, turning those tests red (i.e. failing)
            // 3. Finally, make changes to the code that fix the bug, turning the tests green (i.e. passing)
            if (acc.Balance + tx.TransactionAmount < _overdraftLimit)
                return false;

            return true;
        }
    }
}
