﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo
{
    public class AnalyticsLogger : IAnalyticsLogger
    {
        static string storageconn = "DefaultEndpointsProtocol=https;AccountName=blah;AccountKey=helloworld==;EndpointSuffix=core.windows.net";

        static string table1 = "Customer";
        static string partitionkey = "CustIdentifier";
        static string rowKey = "guid";
        
        private CloudTable table;
        
        public AnalyticsLogger()
        {
            // Logs to Azure Table Storage
            var storageAcc = CloudStorageAccount.Parse(storageconn);
            var tblclient = storageAcc.CreateCloudTableClient();
            table = tblclient.GetTableReference(table1);
            table.CreateIfNotExistsAsync().Wait();
        }

        public bool Log(string message, int severity)
        {
            var logEntry = new LogEntry(partitionkey, message, severity);
            var insertOperation = TableOperation.Insert(logEntry);
            var _ = table.ExecuteAsync(insertOperation).Result;

            return true;
        }
    }
}
