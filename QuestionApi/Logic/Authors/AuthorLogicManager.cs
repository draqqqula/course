using Dal.Authors.Interfaces;
using Logic.Authors.Interfaces;
using Logic.Authors.Models;
using Dal.Authors.Models;
using MyProfileConnectionLib.ConnectionServices.Interfaces;
using MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;

namespace Logic.Authors;

/// <inheritdoc/>
internal class AuthorLogicManager : IAuthorLogicManager
{
    private const string DefaultName = "Default";
    private readonly IAuthorRepository _authorRepository;
    private readonly IProfileConnectionService _profileConnectionService;

    public AuthorLogicManager(IAuthorRepository authorRepository, IProfileConnectionService profileConnection)
    {
        _authorRepository = authorRepository;
        _profileConnectionService = profileConnection;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(AuthorInputModel author)
    {
        var profile = await _profileConnectionService.GetProfileAsync(new GetProfileRequest() 
        { 
            Id = author.ProfileId 
        });
        return await _authorRepository.CreateAsync(new AuthorDal()
        {
            Name = profile?.Name ?? DefaultName,
            Id = author.ProfileId,
        });
    }
}
