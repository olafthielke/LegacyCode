using Microsoft.WindowsAzure.Storage;

namespace Dependencies.BringClassUnderTest.ExtractInterface.Demo
{
    public interface IMessageStore
    {
        void Init(string status, int bucketId);
    }

    public class MessageStore : IMessageStore
    {
        const string TblName = "notifications";


        public MessageStore()
        {

        }

        public void Init(string status, int bucketId)
        {
            if (status.ToUpperInvariant() == "ACTIVE")
            {
                var bucketAcc = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName=acc-{bucketId};AccountKey=notifications==;EndpointSuffix=blah.windows.net");
                
                var cli = bucketAcc.CreateCloudTableClient();
                
                var tbl = cli.GetTableReference(TblName);
                
                tbl.CreateIfNotExistsAsync().Wait();
            }
        }
    }
}
