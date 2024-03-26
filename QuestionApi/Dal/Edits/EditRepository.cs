using Dal.Edits.Interfaces;
using Dal.Edits.Models;

namespace Dal.Edits;

/// <inheritdoc/>
internal class EditRepository : IEditRepository
{
    private readonly QuestionDbContext _dbContext;

    public EditRepository(QuestionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<Guid> AddAsync(EditDal dal)
    {
        dal.Question.Edits.Add(dal);
        await _dbContext.Edits.AddAsync(dal);
        await _dbContext.SaveChangesAsync();
        return dal.Id;
    }
}
