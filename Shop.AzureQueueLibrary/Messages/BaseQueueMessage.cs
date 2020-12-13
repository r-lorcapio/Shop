using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.AzureQueueLibrary.Messages
{
    public  abstract class BaseQueueMessage
    {

        public string Route { get; set; }

        public BaseQueueMessage(string route)
        {
            this.Route = route;
        }
    }
}
