using Domain.Entities;

namespace Services.Interfaces;

public interface IGetProfile
{
    public Task<Profile?> GetProfileAsync(Guid id);
}
