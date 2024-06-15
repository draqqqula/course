using Domain.Entities;

namespace Domain.Interfaces;

public interface IModifyProfile
{
    public Task<Guid> ModifyProfile(Profile profile);
}
