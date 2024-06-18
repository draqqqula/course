using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfileConnectionLib.ConnectionServices.DtoModels;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CreateUser;
using MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAnsweredCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAskedCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceSolvedCounter;
using MyProfileConnectionLib.ConnectionServices.Interfaces;
using System;
using System.Net.Http.Json;

namespace MyProfileConnectionLib.ConnectionServices.Implementations.Http;

internal class HttpProfileConnectionService : IProfileConnectionService
{
    enum RestApiAvailableMethod
    {
        Post,
        Put
    }

    private readonly IHttpClientFactory _httpClientFactory;

    private Uri? CreateUserUri { get; set; }
    private Uri? GetProfileUri { get; set; }
    private Uri? IncreaceAskedUri { get; set; }
    private Uri? IncreaceSolvedUri { get; set; }
    private Uri? IncreaceAnsweredUri { get; set; }

    public HttpProfileConnectionService(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        IncreaceAskedUri = configuration.GetValue<Uri>(nameof(IncreaceAskedUri));
        IncreaceAnsweredUri = configuration.GetValue<Uri>(nameof(IncreaceAnsweredUri));
        IncreaceSolvedUri = configuration.GetValue<Uri>(nameof(IncreaceSolvedUri));
        CreateUserUri = configuration.GetValue<Uri>(nameof(CreateUserUri));
    }

    private async Task<HttpResponseMessage> MakeApiRequest<T>(RestApiAvailableMethod method, Uri? uri, T model)
    {
        using var client = _httpClientFactory.CreateClient();

        switch (method)
        {
            case RestApiAvailableMethod.Put: return await client.PutAsJsonAsync(uri, model);
            case RestApiAvailableMethod.Post: return await client.PostAsJsonAsync(uri, model);
            default: return await client.PostAsJsonAsync(uri, model);
        }
    }

    private async Task<T2?> MakeApiRequest<T1, T2>(RestApiAvailableMethod method, Uri? uri, T1 requestModel)
    {
        if (uri is null)
        {
            return default;
        }

        var response = await MakeApiRequest(method, uri, requestModel);

        var result = await response.Content.ReadFromJsonAsync<T2>();

        return result;
    }

    private async Task<bool> IncreaceCounter(IncreaceCounterRequestBase request, Uri? uri)
    {
        var result = await MakeApiRequest<IncreaceCounterRequestBase, ProfileApiResponse>(RestApiAvailableMethod.Put, uri, request);
        return result is not null && result.Id is not null;
    }

    public async Task<IncreaceAnsweredCounterResponse> IncreaceAnsweredCounter(IncreaceAnsweredCounterRequest request)
    {
        return new IncreaceAnsweredCounterResponse()
        {
            Success = await IncreaceCounter(request, IncreaceAnsweredUri)
        };
    }

    public async Task<IncreaceAskedCounterResponse> IncreaceAskedCounter(IncreaceAskedCounterRequest request)
    {
        return new IncreaceAskedCounterResponse()
        {
            Success = await IncreaceCounter(request, IncreaceAskedUri)
        };
    }

    public async Task<IncreaceSolvedCounterResponse> IncreaceSolvedCounter(IncreaceSolvedCounterRequest request)
    {
        return new IncreaceSolvedCounterResponse()
        {
            Success = await IncreaceCounter(request, IncreaceSolvedUri)
        };
    }

    public async Task<CheckUserExistsProfileApiResponse> CheckUserExistsAsync(CheckUserExistsProfileApiRequest request)
    {
        var result = await GetProfileAsync(new GetProfileRequest() { Id = request.Id });
        return new CheckUserExistsProfileApiResponse()
        {
            Id = result is null ? null : request.Id
        };
    }

    public async Task<CreateUserProfileResponse> CreateUserAsync(CreateUserProfileRequest request)
    {
        return await MakeApiRequest<CreateUserProfileRequest, CreateUserProfileResponse>
            (RestApiAvailableMethod.Post, CreateUserUri, request) ?? new CreateUserProfileResponse()
            {
                Id = default
            };
    }

    public async Task<GetProfileResponse?> GetProfileAsync(GetProfileRequest request)
    {
        using var client = _httpClientFactory.CreateClient();
        if (GetProfileUri is null)
        {
            return null;
        }
        var builder = new UriBuilder(GetProfileUri);
        builder.Query = $"profileId={request.Id}";

        var response = await client.GetFromJsonAsync<GetProfileResponse>(builder.Uri);
        return response;
    }
}
