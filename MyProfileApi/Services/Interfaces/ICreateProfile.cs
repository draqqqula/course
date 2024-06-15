using Domain.Entities;

namespace Services.Interfaces;

public interface ICreateProfile
{
    public Task<Guid> CreateProfileAsync(Profile profile);
}
