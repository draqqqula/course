using Dal.Questions.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Questions.Interfaces;

/// <summary>
/// Хранение вопросов
/// </summary>
public interface IQuestionRepository
{
    /// <summary>
    /// Создать вопрос
    /// </summary>
    /// <param name="dal"></param>
    /// <returns></returns>
    public Task<Guid> CreateAsync(QuestionDal dal);

    /// <summary>
    /// Получить все вопросы
    /// </summary>
    /// <returns></returns>
    public IQueryable<QuestionDal> GetAll();

    /// <summary>
    /// Получить информацию о вопросе
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<QuestionDal?> GetInfoAsync(Guid id);

    /// <summary>
    /// Отметить ответ как решение
    /// </summary>
    /// <param name="answerId"></param>
    /// <returns></returns>
    public Task<Guid?> AcceptSolutionAsync(Guid answerId);

    /// <summary>
    /// Удалить вопрос
    /// </summary>
    /// <param name="answerId"></param>
    /// <returns></returns>
    public Task<Guid?> RemoveAsync(Guid answerId);
}
