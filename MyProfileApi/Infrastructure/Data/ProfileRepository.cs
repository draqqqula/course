using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Data
{
    internal class ProfileRepository : IStoreProfile, ITakeProfile, IModifyProfile
    {
        private readonly ProfileDbContext _dbContext;

        public ProfileRepository(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddProfile(Profile profile)
        {
            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return profile.Id;
        }

        public async Task<Profile?> GetProfile(Guid id)
        {
            return await _dbContext.Profiles.FindAsync(id);
        }

        public async Task<Guid> ModifyProfile(Profile profile)
        {
            await _dbContext.SaveChangesAsync();
            return profile.Id;
        }
    }
}
