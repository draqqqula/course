using Dal.Answers.Models;
using Dal.Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Answers.Interfaces
{
    /// <summary>
    /// Хранение ответов
    /// </summary>
    public interface IAnswerRepository
    {
        /// <summary>
        /// Создать ответ
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public Task<Guid> CreateAsync(AnswerDal answer);

        /// <summary>
        /// Удалить ответ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Guid?> RemoveAsync(Guid id);
    }
}
