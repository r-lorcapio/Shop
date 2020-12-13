using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Shop.AzureQueueLibrary.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.AzureQueueLibrary.QueueConnection
{
    public interface ICloudQueueClientFactory
    {
        CloudQueueClient GetClient();
    }

    public class CloudQueueClientFactory : ICloudQueueClientFactory
    {
        private readonly QueueConfig queueConfig;
        private CloudQueueClient cloudQueueClient;
        public CloudQueueClientFactory(QueueConfig queueConfig)
        {
            this.queueConfig = queueConfig;
        }

        public CloudQueueClient GetClient()
        {
            if (cloudQueueClient != null)
            {
                return cloudQueueClient;
            }

            
            var storageAccount = CloudStorageAccount.Parse(queueConfig.QueueConnectionString);
            cloudQueueClient = storageAccount.CreateCloudQueueClient();
            return cloudQueueClient;
        }
    }
}
