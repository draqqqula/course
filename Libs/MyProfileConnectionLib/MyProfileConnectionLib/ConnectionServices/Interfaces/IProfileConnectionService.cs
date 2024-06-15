using MyProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using MyProfileConnectionLib.ConnectionServices.DtoModels.CreateUser;
using MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAnsweredCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceAskedCounter;
using MyProfileConnectionLib.ConnectionServices.DtoModels.IncreaceSolvedCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProfileConnectionLib.ConnectionServices.Interfaces;

public interface IProfileConnectionService
{
    public Task<GetProfileResponse?> GetProfileAsync(GetProfileRequest request);
    public Task<CreateUserProfileResponse> CreateUserAsync(CreateUserProfileRequest request);
    public Task<CheckUserExistsProfileApiResponse> CheckUserExistsAsync(CheckUserExistsProfileApiRequest request);
    public Task<IncreaceAskedCounterResponse> IncreaceAskedCounter(IncreaceAskedCounterRequest request);
    public Task<IncreaceAnsweredCounterResponse> IncreaceAnsweredCounter(IncreaceAnsweredCounterRequest request);
    public Task<IncreaceSolvedCounterResponse> IncreaceSolvedCounter(IncreaceSolvedCounterRequest request);
}
