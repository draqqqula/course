using Api.Controllers;
using Core.Logic.Handling.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Api.Listeners.Handlers;

public class CreateProfileHandler : IAsyncRequestHandler<CreateProfileRequest, CreateProfileResponse>
{
    private readonly IServiceScopeFactory _scopeFactory;
    public CreateProfileHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<CreateProfileResponse> HandleAsync(CreateProfileRequest request)
    {
        using var scope = _scopeFactory.CreateScope();
        var id = await scope.ServiceProvider.GetRequiredService<ICreateProfile>().CreateProfileAsync(new Profile
        {
            Name = request.Name,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        });
        return new CreateProfileResponse()
        {
            Id = id
        };
    }
}
