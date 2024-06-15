using Domain.Entities;
using Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

internal abstract class IncreaceCounterBase : IIncreaceCounter
{
    private readonly ITakeProfile _takeProfile;
    private readonly IModifyProfile _modifyProfile;

    public IncreaceCounterBase(ITakeProfile takeProfile, IModifyProfile modifyProfile)
    {
        _takeProfile = takeProfile;
        _modifyProfile = modifyProfile;
    }
    public async Task<Guid?> IncreaceCounterAsync(Guid id, int amount)
    {
        var profile = await _takeProfile.GetProfile(id);
        if (profile is null)
        {
            return default;
        }
        Increace(profile, amount);
        await _modifyProfile.ModifyProfile(profile);
        return profile.Id;
    }

    protected abstract void Increace(Profile profile, int amount);
}
