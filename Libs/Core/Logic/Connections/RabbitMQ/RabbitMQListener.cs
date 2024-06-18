using Core.Logic.Connections.RabbitMQ.Generators;
using Core.Logic.Connections.RabbitMQ.Interfaces;
using Core.Logic.Handling.Interfaces;
using Core.Logic.Serialization.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Core.Logic.Connections.RabbitMQ;

internal class RabbitMQListener : IRabbitMQListener
{
    private readonly IModel _channel;
    private readonly IRabbitMQPublisher _publisher;
    private readonly IQueueNameGenerator _generator;
    private readonly IBinarySerializer _serializer;

    public RabbitMQListener(IRabbitMQPublisher publisher, 
        IRabbitMQChannelFactory factory,
        IQueueNameGenerator generator,
        IBinarySerializer serializer)
    {
        _publisher = publisher;
        _channel = factory.Create();
        _generator = generator;
        _serializer = serializer;
    }

    public void StartListening<TRequest, TResponse>(IAsyncRequestHandler<TRequest, TResponse> handler)
    {
        var queueName = _generator.GenerateForRequests<TRequest>();
        var consumer = new EventingBasicConsumer(_channel);
        _channel.QueueDeclare(queueName, false, false, false);
        consumer.Received += async (_, args) => await HandleRequestAsync(args, handler);
        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
    }

    private async Task HandleRequestAsync<TRequest, TResponse>(BasicDeliverEventArgs args, IAsyncRequestHandler<TRequest, TResponse> handler)
    {
        var queueName = args.BasicProperties.ReplyTo;
        var request = _serializer.Deserialize<TRequest>(args.Body.ToArray());
        if (request is null)
        {
            throw new NotImplementedException();
        }
        var respose = await handler.HandleAsync(request);
        var properties = _channel.CreateBasicProperties();
        properties.CorrelationId = args.BasicProperties.CorrelationId;
        _publisher.Publish(respose, _channel, new Models.PublishArguments()
        {
            ExchangeName = queueName,
            RoutingKey = queueName,
            Properties = properties
        });
    }
}
