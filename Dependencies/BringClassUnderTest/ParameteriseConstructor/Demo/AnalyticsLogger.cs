using Microsoft.WindowsAzure.Storage;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo
{
    public class AnalyticsLogger : IAnalyticsLogger
    {
        static string storageconn = "DefaultEndpointsProtocol=https;AccountName=blah;AccountKey=helloworld==;EndpointSuffix=core.windows.net";

        static string table1 = "Customer";
        static string partitionkey = "CustIdentifier";
        static string rowKey = "guid";

        public AnalyticsLogger()
        {
            // Logs to Azure Table Storage
            var storageAcc = CloudStorageAccount.Parse(storageconn);
            var tblclient = storageAcc.CreateCloudTableClient();
            var table = tblclient.GetTableReference(table1);
            table.CreateIfNotExistsAsync().Wait();
        }

        public bool Log(string message, int severity)
        {
            // ...

            return true;
        }
    }
}
