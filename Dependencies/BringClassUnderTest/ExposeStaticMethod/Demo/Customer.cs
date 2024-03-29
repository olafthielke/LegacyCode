﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo
{
    public class Customer
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public CustomerCategory Category { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public int LoyaltyScore { get; set; }
        public bool ManualCheckDone { get; set; }
        public bool CreatedByAdmin { get; set; }
    }

    public enum CustomerCategory
    {
        Unknown,
        REG,
        HVP,
        LOC
    }
}
