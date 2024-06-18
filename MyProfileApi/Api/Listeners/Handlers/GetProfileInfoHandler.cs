using Api.Controllers;
using Api.Listeners.Models;
using Core.Logic.Handling.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Api.Listeners.Handlers;

public class GetProfileInfoHandler : IAsyncRequestHandler<GetProfileRequest, GetProfileResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;
    public GetProfileInfoHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    public async Task<GetProfileResponse> HandleAsync(GetProfileRequest request)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var profile = await scope.ServiceProvider.GetRequiredService<IGetProfile>().GetProfileAsync(request.Id);
            return new GetProfileResponse
            {
                Name = profile?.Name ?? "NotFound",
                Description = profile?.Description ?? "Empty",
                Reputation = profile?.Reputation ?? 0,
                AnsweredCount = profile?.AnsweredCount ?? 0,
                AskedCount = profile?.AskedCount ?? 0,
                SolvedCount = profile?.SolvedCount ?? 0,
            };
        }
    }
}
