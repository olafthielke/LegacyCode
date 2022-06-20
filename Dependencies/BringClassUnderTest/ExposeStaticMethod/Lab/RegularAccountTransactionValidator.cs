using System;
using System.Configuration;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Lab
{
    public class RegularAccountTransactionValidator
    {
        private decimal _overdraftLimit;
        private decimal _maximumDepositAmount;

        public RegularAccountTransactionValidator()
        {
            var limitsString = ConfigurationManager.AppSettings["RegularAccountLimits"];
            var limits = limitsString.Split('|');

            _overdraftLimit = Convert.ToDecimal(limits[0]);
            _maximumDepositAmount = Convert.ToDecimal(limits[1]);

            // Assume that this class is very difficult to get under test,
            // maybe because it has many concrete instantiations of other
            // services.

            // ...

            // Similate the inability to call create an instance of this class by
            // throwing an exception:
            throw new InvalidOperationException();
        }

        public bool Validate(BankTransaction tx, BankAccount acc)
        {
            if (tx == null || acc == null)
                return false;

            if (tx.AccountNumber != acc.AccountNumber)
                return false;

            if (acc.Balance + tx.TransactionAmount < _overdraftLimit)
                return false;

            return true;
        }
    }
}
