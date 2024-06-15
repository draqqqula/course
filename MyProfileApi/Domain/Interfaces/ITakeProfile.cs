using Domain.Entities;

namespace Domain.Interfaces;

public interface ITakeProfile
{
    public Task<Profile?> GetProfile(Guid id);
}
