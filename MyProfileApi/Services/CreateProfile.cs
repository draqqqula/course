using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

internal class CreateProfile : ICreateProfile
{
    private readonly IStoreProfile _storeProfile;
    public CreateProfile(IStoreProfile storeProfile)
    {
        _storeProfile = storeProfile;
    }

    public Task<Guid> CreateProfileAsync(Profile profile)
    {
        return _storeProfile.AddProfile(profile);
    }
}
