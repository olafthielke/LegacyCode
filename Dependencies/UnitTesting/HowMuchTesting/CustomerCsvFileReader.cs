using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Dependencies.UnitTesting.HowMuchTesting
{
    public class CustomerCsvFileReader
    {
        // Method to read customer data from various file formats
        public async Task<IEnumerable<Customer>> ReadAllCustomers()
        {
            const string customerFilePath = @"C:\Production\CustomerApp\Data\Customers.csv";

            var customers = new List<Customer>();
            
            try
            {
                string[] lines = File.ReadAllLines(customerFilePath);
                foreach (string line in lines)
                {
                    string[] customerData = line.Split(',');

                    var address = CustomerAddressLookup.LookupAddress(int.Parse(customerData[0]));
                    
                    var customer = new Customer()
                    {
                        CustomerNumber = int.Parse(customerData[0]),
                        FirstName = customerData[1],
                        LastName = customerData[2],
                        Email = customerData[3],
                        // TODO: Add a customer's loyalty number to Customer objects.                        
                        //LoyaltyNumber = int.Parse(customerData[4]),
                        Address = address
                    };

                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV: {ex.Message}");
            }

            return customers;
        }
    }
}