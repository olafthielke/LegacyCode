using System;

namespace Dependencies.BringMethodUnderTest.PassNull.Lab
{
    public class Customer
    {
        public string CustomerNumber { get; set; }
        public Salutation Salutation { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int? LoyaltyMembershipNumber { get; set; }
        public string AddressGeoCode { get; set; }

        public LoyaltyScheme LoyaltyScheme { get; set; }
        public int LoyaltyPoints { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string TownOrCity { get; set; }
        public int PostCode { get; set; }
    }
}
