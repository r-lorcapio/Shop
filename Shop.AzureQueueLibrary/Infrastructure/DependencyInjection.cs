using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Shop.AzureQueueLibrary.MessageSerializer;
using Shop.AzureQueueLibrary.QueueConnection;

namespace Shop.AzureQueueLibrary.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAzureQueueLibrary(this IServiceCollection services, string queueConnectionString)
        {
            services.AddSingleton(new QueueConfig(queueConnectionString));
            services.AddSingleton<ICloudQueueClientFactory, CloudQueueClientFactory>();
            services.AddSingleton<IMessageSerializer, JsonMessageSerializer>();
            services.AddTransient<IQueueCommunicator, QueueCommunicator>();
            return services;
        }
    }
}
