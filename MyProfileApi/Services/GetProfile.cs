using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

internal class GetProfile : IGetProfile
{
    private readonly ITakeProfile _takeProfile;
    public GetProfile(ITakeProfile takeProfile)
    {
        _takeProfile = takeProfile;
    }

    public Task<Profile?> GetProfileAsync(Guid id)
    {
        return _takeProfile.GetProfile(id);
    }
}
