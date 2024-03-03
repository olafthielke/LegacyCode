namespace Dependencies.BringClassUnderTest.ExposeStaticMethod.Demo
{
    public sealed class GlobalConfig
    {
        private GlobalConfig() { }

        private static GlobalConfig _instance = null;

        public static GlobalConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalConfig();
                }
                return _instance;
            }
        }

        public bool IsServiceEnabled
        {
            get
            {
                var isServiceEnabled = false;
                
                // Retrieve config

                return isServiceEnabled;
            }
        }

        public string ConnString
        {
            get
            {
                string connString = "default production connection string";

                // Retrieve config

                return connString;
            }
        }
    }
}
