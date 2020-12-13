using Microsoft.WindowsAzure.Storage.Queue;
using Shop.AzureQueueLibrary.Messages;
using Shop.AzureQueueLibrary.MessageSerializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.AzureQueueLibrary.QueueConnection
{
    public interface IQueueCommunicator
    {
        T Read<T>(string message);
        Task SendAsync<T>(T obj) where T : BaseQueueMessage;
    }
    public class QueueCommunicator : IQueueCommunicator
    {
        private readonly IMessageSerializer messageSerializer;
        private readonly ICloudQueueClientFactory cloudQueueClientFactory;

        public QueueCommunicator(IMessageSerializer  messageSerializer, ICloudQueueClientFactory cloudQueueClientFactory )
        {
            this.messageSerializer = messageSerializer;
            this.cloudQueueClientFactory = cloudQueueClientFactory;
        }

        public T Read<T>(string message)
        {
            return messageSerializer.Deseralize<T>(message);
        }

        public async Task SendAsync<T>(T obj) where T : BaseQueueMessage
        {
            var queueReference = cloudQueueClientFactory.GetClient().GetQueueReference(obj.Route);
            await queueReference.CreateIfNotExistsAsync();

            var serializeMessage = messageSerializer.Serialize(obj);
            var queueMessage = new CloudQueueMessage(serializeMessage);

            await queueReference.AddMessageAsync(queueMessage);
        }

    }
}
