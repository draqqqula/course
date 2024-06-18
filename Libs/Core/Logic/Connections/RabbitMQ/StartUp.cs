using Core.Logic.Connections.RabbitMQ.Generators;
using Core.Logic.Connections.RabbitMQ.Generators.CorrelationId;
using Core.Logic.Connections.RabbitMQ.Generators.QueueName;
using Core.Logic.Connections.RabbitMQ.Interfaces;
using Core.Logic.Serialization;
using Core.Logic.Serialization.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Logic.Connections.RabbitMQ;

public static class StartUp
{
    public static void TryAddRabbitMQ(this IServiceCollection services)
    {
        services.AddSingleton<ICorrelationIdGenerator, CorrelationIdGenerator>();
        services.AddSingleton<IQueueNameGenerator, QueueNameGenerator>();
        services.AddSingleton<IRabbitMQChannelFactory, RabbitMQChannelFactory>();
        services.AddSingleton<IBinarySerializer, JsonBinarySerializer>();
        services.AddSingleton<IRabbitMQPublisher, RabbitMQPublisher>();
        services.AddSingleton<IRabbitMQListener, RabbitMQListener>();
        services.AddSingleton<IRabbitMQClient, RabbitMQClient>();
    }
}
