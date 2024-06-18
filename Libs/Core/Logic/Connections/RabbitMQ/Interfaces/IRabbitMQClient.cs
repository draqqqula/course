namespace Core.Logic.Connections.RabbitMQ.Interfaces;

public interface IRabbitMQClient
{
    public Task<TResponse?> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken);
}
