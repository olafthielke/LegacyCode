using System;
using System.Configuration;

namespace Dependencies.BringClassUnderTest.PrimitiviseParameter.Lab
{
    public class ConnectionStringConfig
    {
        private readonly string _sharded;

        public DatabasesConfig DatabasesConfig { get; set; }
          
        public ConnectionStringConfig()
        {
            _sharded = ConfigurationManager.AppSettings["Sharded"];
            if (_sharded == null)
                throw new Exception("The Sharded flag must be configured!");
        }
    }

    public class DatabasesConfig
    {
        public DatabaseConfig DatabaseConfig { get; set; }
    }

    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
    }
}
