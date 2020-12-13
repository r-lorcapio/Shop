using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.AzureQueueLibrary.MessageSerializer
{
    public class JsonMessageSerializer : IMessageSerializer
    {
        public T Deseralize<T>(string message)
        {
            return JsonConvert.DeserializeObject<T>(message);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
