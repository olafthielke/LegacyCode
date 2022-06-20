using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.IO;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public class CommissionConfig
    {
        public int Commission { get; set; }
        public bool NetTax { get; set; }
        public bool ApplyImmediately { get; set; }
    }
}
