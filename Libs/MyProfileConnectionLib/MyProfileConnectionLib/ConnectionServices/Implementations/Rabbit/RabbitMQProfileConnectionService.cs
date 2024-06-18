using Core.Logic.Connections.RabbitMQ.Interfaces;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CreateUser;
using MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAnsweredCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAskedCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceSolvedCounter;
using MyProfileConnectionLib.ConnectionServices.Interfaces;

namespace MyProfileConnectionLib.ConnectionServices.Implementations.Rabbit;

internal class RabbitMQProfileConnectionService : IProfileConnectionService
{
    private readonly IRabbitMQClient _client;

    public RabbitMQProfileConnectionService(IRabbitMQClient client)
    {
        _client = client;
    }

    public async Task<CheckUserExistsProfileApiResponse> CheckUserExistsAsync(CheckUserExistsProfileApiRequest request)
    {
        return await _client.SendAsync<CheckUserExistsProfileApiRequest, CheckUserExistsProfileApiResponse>(request, CancellationToken.None);
    }

    public async Task<CreateUserProfileResponse> CreateUserAsync(CreateUserProfileRequest request)
    {
        return await _client.SendAsync<CreateUserProfileRequest, CreateUserProfileResponse>(request, CancellationToken.None);
    }

    public async Task<GetProfileResponse?> GetProfileAsync(GetProfileRequest request)
    {
        return await _client.SendAsync<GetProfileRequest, GetProfileResponse>(request, CancellationToken.None);
    }

    public async Task<IncreaceAnsweredCounterResponse> IncreaceAnsweredCounter(IncreaceAnsweredCounterRequest request)
    {
        return await _client.SendAsync<IncreaceAnsweredCounterRequest, IncreaceAnsweredCounterResponse>(request, CancellationToken.None);
    }

    public async Task<IncreaceAskedCounterResponse> IncreaceAskedCounter(IncreaceAskedCounterRequest request)
    {
        return await _client.SendAsync<IncreaceAskedCounterRequest, IncreaceAskedCounterResponse>(request, CancellationToken.None);
    }

    public async Task<IncreaceSolvedCounterResponse> IncreaceSolvedCounter(IncreaceSolvedCounterRequest request)
    {
        return await _client.SendAsync<IncreaceSolvedCounterRequest, IncreaceSolvedCounterResponse>(request, CancellationToken.None);
    }
}
