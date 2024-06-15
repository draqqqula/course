using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.IncreaceCounter;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public static class StartUp
{
    public static IServiceCollection TryAddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<ICreateProfile, CreateProfile>();
        serviceCollection.TryAddScoped<IGetProfile, GetProfile>();
        serviceCollection.TryAddKeyedScoped<IIncreaceCounter, IncreaceAnsweredCounter>("answered");
        serviceCollection.TryAddKeyedScoped<IIncreaceCounter, IncreaceAskedCounter>("asked");
        serviceCollection.TryAddKeyedScoped<IIncreaceCounter, IncreaceSolvedCounter>("solved");
        return serviceCollection;
    }
}
