using Core.Logic.Connections.RabbitMQ.Generators;
using Core.Logic.Connections.RabbitMQ.Interfaces;
using Core.Logic.Serialization.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;
using CallbackMapper = System.Collections.Generic.Dictionary<string, System.Threading.Tasks.TaskCompletionSource<byte[]>>;

namespace Core.Logic.Connections.RabbitMQ;

internal class RabbitMQClient : IRabbitMQClient
{
    private readonly string _responseQueueName;
    private readonly IModel _channel;
    private readonly IRabbitMQPublisher _publisher;
    private readonly ICorrelationIdGenerator _idGenerator;
    private readonly IQueueNameGenerator _nameGenerator;
    private readonly IBinarySerializer _serializer;
    private readonly CallbackMapper _mapper;
    public RabbitMQClient(ICorrelationIdGenerator idGenerator, 
        IRabbitMQPublisher publisher, 
        IQueueNameGenerator nameGenerator,
        IBinarySerializer serializer,
        IRabbitMQChannelFactory factory)
    {
        _idGenerator = idGenerator;
        _publisher = publisher;
        _nameGenerator = nameGenerator;
        _mapper = new CallbackMapper();
        _serializer = serializer;
        _channel = factory.Create();
        _responseQueueName = DeclareResponseQueue();
        StartListeningForResponses();
    }

    private void StartListeningForResponses()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (_, args) => HandleResponseReceived(args);
        _channel.BasicConsume(consumer: consumer, queue: _responseQueueName, autoAck: true);
    }

    private void HandleResponseReceived(BasicDeliverEventArgs args)
    {
        if (!_mapper.Remove(args.BasicProperties.CorrelationId, out var tcs))
        {
            return;
        }
        tcs.TrySetResult(args.Body.ToArray());
    }

    private string DeclareResponseQueue()
    {
        var queueName = _nameGenerator.GenerateForResponses();
        _channel.ExchangeDeclare(queueName, ExchangeType.Direct);
        _channel.QueueDeclare(queueName, false, false, false, null);
        _channel.QueueBind(queueName, queueName, queueName);
        return queueName;
    }

    public async Task<TResponse?> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
    {
        var correlationId = _idGenerator.Generate();
        var queueName = _nameGenerator.GenerateForRequests<TRequest>();

        var properties = _channel.CreateBasicProperties();

        _channel.ExchangeDeclare(queueName, ExchangeType.Direct);
        _channel.QueueDeclare(queueName, false, false, false, null);
        _channel.QueueBind(queueName, queueName, queueName);

        properties.ReplyTo = _responseQueueName;
        properties.CorrelationId = correlationId;

        _publisher.Publish(request, _channel, new Models.PublishArguments()
        {
            ExchangeName = queueName,
            RoutingKey = queueName,
            Properties = properties
        });
        var response = await WaitForResponseAsync<TResponse?>(correlationId, cancellationToken);
        return response;
    }

    private async Task<TResponse?> WaitForResponseAsync<TResponse>(string correlationId, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<byte[]>();
        _mapper.TryAdd(correlationId, tcs);
        cancellationToken.Register(() => _mapper.Remove(correlationId));
        var responseData = await tcs.Task;

        return _serializer.Deserialize<TResponse>(responseData);
    }
}
