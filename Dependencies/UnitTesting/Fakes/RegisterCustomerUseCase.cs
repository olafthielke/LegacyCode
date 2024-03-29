﻿using System.Threading.Tasks;

namespace Dependencies.UnitTesting.Fakes
{
    public class RegisterCustomerUseCase
    {
        public ICustomerRepository Repository { get; }
        public ICustomerNotifier Notifier { get; }


        public RegisterCustomerUseCase(ICustomerRepository repository,
            ICustomerNotifier notifier)
        {
            Repository = repository;
            Notifier = notifier;
        }


        public async Task<Customer> RegisterCustomer(CustomerRegistration reg)
        {
            await Validate(reg);
            var customer = reg.ToCustomer();
            await Repository.SaveCustomer(customer);
            await Notifier.SendWelcomeMessage(customer);
            return customer;
        }


        private async Task Validate(CustomerRegistration reg)
        {
            if (reg == null)
                throw new MissingCustomerRegistration();
            reg.Validate();
            var existCust = await Repository.GetCustomer(reg.EmailAddress);
            if (existCust != null)
                throw new DuplicateCustomerEmailAddress(reg.EmailAddress);
        }
    }
}