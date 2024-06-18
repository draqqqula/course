using Core.Logic.Connections.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfileConnectionLib.ConnectionServices.Implementations;
using MyProfileConnectionLib.ConnectionServices.Implementations.Http;
using MyProfileConnectionLib.ConnectionServices.Implementations.Rabbit;
using MyProfileConnectionLib.ConnectionServices.Interfaces;

namespace MyProfileConnectionLib;

public static class StartUp
{
    public static void TryAddProfileConnection(this IServiceCollection services)
    {
        services.TryAddRabbitMQ();
        services.AddKeyedSingleton<IProfileConnectionService, RabbitMQProfileConnectionService>("RabbitMQ");
        services.AddKeyedSingleton<IProfileConnectionService, HttpProfileConnectionService>("http");
        services.AddSingleton<IProfileConnectionService, ProfileConnectionServiceDecorator>();
    }
}
