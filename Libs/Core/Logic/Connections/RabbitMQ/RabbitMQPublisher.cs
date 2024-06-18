using Core.Logic.Connections.RabbitMQ.Interfaces;
using Core.Logic.Connections.RabbitMQ.Models;
using Core.Logic.Serialization.Interfaces;
using RabbitMQ.Client;

namespace Core.Logic.Connections.RabbitMQ;

internal class RabbitMQPublisher : IRabbitMQPublisher
{
    private readonly IBinarySerializer _serializer;
    public RabbitMQPublisher(IBinarySerializer serializer)
    {
        _serializer = serializer;
    }

    public void Publish<T>(T message, IModel channel, PublishArguments arguments)
    {
        var data = _serializer.Serialize(message);
        channel.BasicPublish(arguments.ExchangeName, arguments.RoutingKey, arguments.Properties, data);
    }
}
