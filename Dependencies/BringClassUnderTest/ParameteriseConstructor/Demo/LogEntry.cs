using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Dependencies.BringClassUnderTest.ParameteriseConstructor.Demo
{

    public class LogEntry : ITableEntity
    {
        public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            // TODO
        }

        public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            // TODO
            return new Dictionary<string, EntityProperty>();
        }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Message { get; set; }
        public int Severity { get; set; }
        public string ETag { get; set; }

        public LogEntry()
        {
        }

        public LogEntry(string partitionKey, string message, int severity)
        {
            PartitionKey = partitionKey;
            RowKey = Guid.NewGuid().ToString(); // Unique identifier for the log entry
            Message = message;
            Severity = severity;
        }
    }
}