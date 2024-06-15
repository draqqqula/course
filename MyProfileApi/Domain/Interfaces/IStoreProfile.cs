using Domain.Entities;

namespace Domain.Interfaces;

public interface IStoreProfile
{
    public Task<Guid> AddProfile(Profile profile);
}
