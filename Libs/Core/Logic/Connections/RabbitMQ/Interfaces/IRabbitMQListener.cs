using Core.Logic.Handling.Interfaces;

namespace Core.Logic.Connections.RabbitMQ.Interfaces;

public interface IRabbitMQListener
{
    public void StartListening<TRequest, TResponse>(IAsyncRequestHandler<TRequest, TResponse> handler);
}
