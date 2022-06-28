using System;
using System.Threading.Tasks;

namespace Dependencies.BringMethodUnderTest.PassNull.Demo
{
    public class CustomerFetcher
    {
        private ICustomerDetailsFetcher DetailsFetcher { get; }
        private AddressFetcher AddressFetcher { get; set; }


        public CustomerFetcher() 
            : this(new CustomerDetailsFetcher())
        { }

        public CustomerFetcher(ICustomerDetailsFetcher detailsFetcher)
        {
            DetailsFetcher = detailsFetcher;
        }


        public async Task<Customer> FetchCustomer(string custNo, bool fetchAddress = true)
        {
            var customer = new Customer();

            var details = await DetailsFetcher.FetchDetails(custNo);
            if (details == null)
                return null;

            // TODO: If details.CustomerId starts with 'C' then strip off the 'C' before assigning to customer.CustomerNumber
            // since it's coming from the old system. On the other hand, if details.CustomerId does not start with a 'C' then
            // just assign to customer.CustomerNumber, ie. the current behaviour.
            customer.CustomerNumber = details.CustomerId.StartsWith("C") ? details.CustomerId.Substring(1) : details.CustomerId;

            customer.Salutation = (Salutation)details.Salutation;
            customer.FirstName = details.FirstName;
            customer.LastName = details.LastName;
            customer.DOB = DateTime.Parse(details.Birthdate); // Format: "2022-05-24"
            customer.AddressGeoCode = details.AddressGeoCode;


            if (fetchAddress)
            {
                AddressFetcher = new AddressFetcher();

                var address = await AddressFetcher.FetchAddress(customer.AddressGeoCode, "DELIVERY");
                if (address == null)
                    throw new MissingDeliveryAddress(customer.CustomerNumber);

                customer.StreetNumber = address.StreetNo?.Trim();
                customer.StreetName = address.Street;
                customer.Suburb = address.Suburb;
                customer.TownOrCity = address.Town;
                customer.PostCode = int.Parse(address.Postcode);

                // ...
            }

            // ...

            return customer;
        }
    }
}
