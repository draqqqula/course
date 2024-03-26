using Core.Exceptions;
using Dal.Edits.Models;
using Dal.Questions.Interfaces;
using Dal.Questions.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Questions;

/// <inheritdoc/>
internal class QuestionRepository : IQuestionRepository
{
    private readonly QuestionDbContext _dbContext;

    public QuestionRepository(QuestionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<Guid?> AcceptSolutionAsync(Guid answerId)
    {
        var answer = await _dbContext.Answers.FindAsync(answerId);
        if (answer is null)
        {
            return null;
        }
        answer.Question.SolutionId = answerId;
        await _dbContext.SaveChangesAsync();
        return answerId;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(QuestionDal question)
    {
        await _dbContext.Questions.AddAsync(question);
        await _dbContext.SaveChangesAsync();
        return question.Id;
    }

    /// <inheritdoc/>
    public async Task<Guid> EditAsync(EditDal dal)
    {
        dal.Question.Edits.Add(dal);
        await _dbContext.Edits.AddAsync(dal);
        await _dbContext.SaveChangesAsync();
        return dal.Id;
    }

    /// <inheritdoc/>
    public IQueryable<QuestionDal> GetAll()
    {
        return _dbContext.Questions;
    }

    /// <inheritdoc/>
    public async Task<QuestionDal?> GetInfoAsync(Guid id)
    {
        return await _dbContext.Questions.FindAsync(id);
    }

    /// <inheritdoc/>
    public async Task<Guid?> RemoveAsync(Guid id)
    {
        var dal = await _dbContext.Questions.FindAsync(id);
        if (dal is null)
        {
            throw new DataNotFoundException($"Вопрос с идентификатором \"{id}\" не найден.");
        }
        if (dal?.Answers.Count > 0)
        {
            throw new ForbiddenRemovalException("Вопрос может быть удалён только если не содержит ответов.");
        }
        _dbContext.Questions.Remove(dal);
        await _dbContext.SaveChangesAsync();
        return dal.Id;
    }
}
