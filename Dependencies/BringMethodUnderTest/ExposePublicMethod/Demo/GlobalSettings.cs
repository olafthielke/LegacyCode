namespace Dependencies.BringMethodUnderTest.ExposePublicMethod.Demo
{
    public static class GlobalSettings
    {
        public static string GetTransactionValidationMode()
        {
            var transactionValidationModel = "Extended";

            
            // read from config file or database
            
            
            return transactionValidationModel;
        }
    }
}
