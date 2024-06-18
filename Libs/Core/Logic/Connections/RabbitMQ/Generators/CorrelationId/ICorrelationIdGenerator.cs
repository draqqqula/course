namespace Core.Logic.Connections.RabbitMQ.Generators;

public interface ICorrelationIdGenerator
{
    public string Generate();
}
