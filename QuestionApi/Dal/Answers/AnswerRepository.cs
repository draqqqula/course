using Core.Exceptions;
using Dal.Answers.Interfaces;
using Dal.Answers.Models;
using Dal.Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Answers
{
    /// <inheritdoc/>
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuestionDbContext _dbContext;

        public AnswerRepository(QuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<Guid> CreateAsync(AnswerDal answer)
        {
            await _dbContext.AddAsync(answer);
            await _dbContext.SaveChangesAsync();
            return answer.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> RemoveAsync(Guid id)
        {
            var dal = await _dbContext.Answers.FindAsync(id);

            if (dal is null)
            {
                throw new DataNotFoundException($"Ответ с идентификатором \"{id}\" не найден.");
            }
            if (dal.Question.SolutionId == id)
            {
                throw new ForbiddenRemovalException("Ответ не можнет быть удалён если он уже был помечен как решение.");
            }

            _dbContext.Remove(dal);
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
