using RabbitMQ.Client;

namespace Core.Logic.Connections.RabbitMQ.Interfaces;

public interface IRabbitMQChannelFactory
{
    public IModel Create();
}