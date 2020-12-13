using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.AzureQueueLibrary.MessageSerializer
{
    public interface IMessageSerializer
    {

        T Deseralize<T>(string message);

        string Serialize(object obj);
    }
}
