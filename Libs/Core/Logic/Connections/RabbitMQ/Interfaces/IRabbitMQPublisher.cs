using Core.Logic.Connections.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Core.Logic.Connections.RabbitMQ.Interfaces;

public interface IRabbitMQPublisher
{
    public void Publish<T>(T message, IModel channel, PublishArguments arguments);
}
