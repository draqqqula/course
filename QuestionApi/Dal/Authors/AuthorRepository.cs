using Dal.Authors.Interfaces;
using Dal.Authors.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Authors;

/// <inheritdoc/>
internal class AuthorRepository : IAuthorRepository
{
    private readonly QuestionDbContext _dbContext;

    public AuthorRepository(QuestionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(AuthorDal author)
    {
        await _dbContext.Authors.AddAsync(author);
        await _dbContext.SaveChangesAsync();
        return author.Id;
    }

    /// <inheritdoc/>
    public async Task<AuthorDal> GetInfoAsync(Guid authorId)
    {
        var author = await _dbContext.Authors.FirstOrDefaultAsync(u => u.Id == authorId);
        return author;
    }
}
