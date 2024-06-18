using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CreateUser;
using MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAnsweredCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAskedCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceSolvedCounter;
using MyProfileConnectionLib.ConnectionServices.Interfaces;

namespace MyProfileConnectionLib.ConnectionServices.Implementations;

internal class ProfileConnectionServiceDecorator : IProfileConnectionService
{
    private readonly IProfileConnectionService _connectionService;

    public ProfileConnectionServiceDecorator(IServiceProvider provider, IConfiguration configuration)
    {
        var connectionType = configuration.GetValue<string>("ProfileLibConnectionType");
        _connectionService = provider.GetRequiredKeyedService<IProfileConnectionService>(connectionType);
    }

    public async Task<CheckUserExistsProfileApiResponse> CheckUserExistsAsync(CheckUserExistsProfileApiRequest request)
    {
        return await _connectionService.CheckUserExistsAsync(request);
    }

    public async Task<CreateUserProfileResponse> CreateUserAsync(CreateUserProfileRequest request)
    {
        return await _connectionService.CreateUserAsync(request);
    }

    public async Task<GetProfileResponse?> GetProfileAsync(GetProfileRequest request)
    {
        return await _connectionService.GetProfileAsync(request);
    }

    public async Task<IncreaceAnsweredCounterResponse> IncreaceAnsweredCounter(IncreaceAnsweredCounterRequest request)
    {
        return await _connectionService.IncreaceAnsweredCounter(request);
    }

    public async Task<IncreaceAskedCounterResponse> IncreaceAskedCounter(IncreaceAskedCounterRequest request)
    {
        return await _connectionService.IncreaceAskedCounter(request);
    }

    public async Task<IncreaceSolvedCounterResponse> IncreaceSolvedCounter(IncreaceSolvedCounterRequest request)
    {
        return await _connectionService.IncreaceSolvedCounter(request);
    }
}
