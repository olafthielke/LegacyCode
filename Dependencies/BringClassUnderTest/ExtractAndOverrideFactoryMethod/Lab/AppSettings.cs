using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public static class AppSettings
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["TransactionDatabase"].ConnectionString;
    }
}
