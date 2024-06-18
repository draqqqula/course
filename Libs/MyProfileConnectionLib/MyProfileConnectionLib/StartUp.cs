using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfileConnectionLib.ConnectionServices;
using MyProfileConnectionLib.ConnectionServices.Interfaces;

namespace MyProfileConnectionLib;

public static class StartUp
{
    public static void TryAddProfileConnection(this IServiceCollection collection)
    {
        collection.AddSingleton<IProfileConnectionService, ProfileConnectionService>();
    }
}
