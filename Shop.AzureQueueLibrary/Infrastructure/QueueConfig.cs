using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.AzureQueueLibrary.Infrastructure
{
    public class QueueConfig
    {
        public string QueueConnectionString { get; set; }

        public QueueConfig()
        { 
        
        }

        public QueueConfig(string queueConnectionString)
        {
            this.QueueConnectionString = queueConnectionString;
        }
    }

}
