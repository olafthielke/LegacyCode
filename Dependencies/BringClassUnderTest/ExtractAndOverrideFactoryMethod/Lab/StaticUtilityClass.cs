namespace Dependencies.BringClassUnderTest.ExtractAndOverrideFactoryMethod.Lab
{
    public static class StaticUtilityClass
    {
        public static string DecryptConnectionString(string connectionString)
        {
            var plainTextConnString = string.Empty;
            
            // ... Do some decryption here ...
            
            return plainTextConnString;
        }

        public static EmailConfig GetEmailConfig()
        {
            // ... Get email config.

            return new EmailConfig();
        }
    }
}
