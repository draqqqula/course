using Dal.Authors.Interfaces;
using Logic.Authors.Interfaces;
using Logic.Authors.Models;
using Dal.Authors.Models;

namespace Logic.Authors;

/// <inheritdoc/>
internal class AuthorLogicManager : IAuthorLogicManager
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorLogicManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(AuthorInputModel author)
    {
        return await _authorRepository.CreateAsync(new AuthorDal()
        {
            Name = author.AuthorName
        });
    }
}
