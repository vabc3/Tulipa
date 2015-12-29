using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Tulipe.WXService
{
    public class AzLog
    {
        private CloudTable wxLogTable;

        public AzLog()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            wxLogTable = tableClient.GetTableReference("wxlog");
            wxLogTable.CreateIfNotExists();
        }

        public void Log(string user, string message)
        {
            var e1=new CustomerEntity {User = user, Message = message};
            wxLogTable.Execute(TableOperation.Insert(e1));
        }
    }

    public class CustomerEntity : TableEntity
    {
        public CustomerEntity()
        {
            this.PartitionKey = "0";
            this.RowKey = DateTime.UtcNow.Ticks.ToString();
            this.Time = DateTime.UtcNow;
        }

        public DateTime Time { get; set; }

        public string User { get; set; }

        public string Message { get; set; }
    }
}