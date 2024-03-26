using Dal.Tags.Interfaces;
using Dal.Tags.Models;

namespace Dal.Tags;

/// <inheritdoc/>
internal class TagRepository : ITagRepository
{
    private readonly QuestionDbContext _dbContext;

    public TagRepository(QuestionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<TagDal?> FindTagAsync(string text)
    {
        return await _dbContext.Tags.FindAsync(text);
    }

    /// <inheritdoc/>
    public async Task AddRangeAsync(TagDal[] tags)
    {
        await _dbContext.Tags.AddRangeAsync(tags);
        await _dbContext.SaveChangesAsync();
    }
}
