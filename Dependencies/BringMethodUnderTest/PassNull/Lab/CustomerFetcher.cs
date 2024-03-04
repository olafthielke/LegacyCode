using System;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.PassNull.Lab
{
    public class CustomerFetcher
    {
        private CustomerDetailsFetcher DetailsFetcher { get; }
        private LoyaltySchemeFetcher LoyaltyFetcher { get; set; }


        public CustomerFetcher()
        {
            DetailsFetcher = new CustomerDetailsFetcher();
        }


        public async Task<Customer> FetchCustomer(string custNo, bool fetchAddress = true)
        {
            var customer = new Customer();

            var details = await DetailsFetcher.FetchDetails(custNo);
            if (details == null)
                return null;

            // TODO: details.Name contains the customer's full name in '{lastname},{firstname}' format.
            // Please populate the currently empty customer.FirstName and customer.LastName properties.
            customer.CustomerNumber = details.CustomerId;
            customer.Salutation = (Salutation)details.Salutation;
            customer.FullName = details.Name;
            //customer.FirstName = ???;
            //customer.LastName = ???;
            customer.DOB = DateTime.Parse(details.Birthdate); // Format: "2022-05-24"
            customer.LoyaltyMembershipNumber = details.LoyaltyNumber;


            if (!customer.LoyaltyMembershipNumber.HasValue)
            {
                LoyaltyFetcher = new LoyaltySchemeFetcher();

                var loyalty = await LoyaltyFetcher.FetchLoyalty(customer.LoyaltyMembershipNumber.ToString());
                if (loyalty == null)
                    throw new Exception($"Unable to retrieve loyalty membership info for customer '{custNo}'.");

                customer.LoyaltyMembershipNumber = int.Parse(loyalty.MembershipNumber);
                if (loyalty.LoyaltyScheme == "RICH REWARDS")
                {
                    customer.LoyaltyScheme = LoyaltyScheme.RichRewards;
                }
                else
                {
                    customer.LoyaltyScheme = LoyaltyScheme.RacyRipOff;
                }
                customer.LoyaltyPoints = loyalty.LoyaltyPoints;

                // ...
            }

            // ...

            return customer;
        }
    }
}
