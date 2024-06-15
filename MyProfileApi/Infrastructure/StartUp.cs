using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class StartUp
{
    public static IServiceCollection TryAddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<ProfileDbContext>();
        serviceCollection.TryAddScoped<ProfileRepository>();
        serviceCollection.TryAddScoped<IStoreProfile>(provider => provider.GetRequiredService<ProfileRepository>());
        serviceCollection.TryAddScoped<ITakeProfile>(provider => provider.GetRequiredService<ProfileRepository>());
        serviceCollection.TryAddScoped<IModifyProfile>(provider => provider.GetRequiredService<ProfileRepository>());
        return serviceCollection;
    }
}
