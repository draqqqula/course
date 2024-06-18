using Api.Controllers;
using Api.Listeners.Handlers;
using Core.Logic.Connections.RabbitMQ.Interfaces;
using Services.Interfaces;

namespace Api.Listeners;

public class ProfileRabbitMQListener : BackgroundService
{
    private readonly IRabbitMQListener _listener;
    private readonly IServiceProvider _provider;
    public ProfileRabbitMQListener(
        IRabbitMQListener listener,
        IServiceProvider provider)
    {
        _listener = listener;
        _provider = provider;
    }

    protected override Task ExecuteAsync(CancellationToken cancelationToken)
    {
        cancelationToken.ThrowIfCancellationRequested();

        _listener.StartListening(_provider.GetRequiredService<GetProfileInfoHandler>());
        //_listener.StartListening(_createProfile);

        return Task.CompletedTask;
    }
}
