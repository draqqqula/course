namespace Core.Logic.Connections.RabbitMQ.Generators;

public interface IQueueNameGenerator
{
    public string GenerateForRequests<T>();
    public string GenerateForResponses();
}
