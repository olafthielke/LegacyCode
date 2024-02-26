namespace Dependencies.UnitTesting.HowMuchTesting
{
    public class CustomerBuilder
    {
        public static Customer BuildCustomer(string[] customerData, string address)
        {
            var customer = new Customer()
            {
                CustomerNumber = int.Parse(customerData[0]),
                FirstName = customerData[1],
                LastName = customerData[2],
                Email = customerData[3],
                // TODO: Add a customer's loyalty number to Customer objects.                        
                LoyaltyNumber = int.Parse(customerData[4]),
                Address = address
            };
            return customer;
        }
    }
}
