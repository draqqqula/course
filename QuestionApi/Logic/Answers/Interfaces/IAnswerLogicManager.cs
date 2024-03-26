using Logic.Answers.Models;
using Logic.Answers.ViewModels;

namespace Logic.Answers.Interfaces;

/// <summary>
/// Работа с ответами
/// </summary>
public interface IAnswerLogicManager
{
    /// <summary>
    /// Опубликовать ответ
    /// </summary>
    /// <param name="answer"></param>
    /// <returns></returns>
    public Task<Guid> PublishAsync(AnswerInputModel answer);

    /// <summary>
    /// Получить ответы по уникальному идентификатору вопроса
    /// </summary>
    /// <param name="questionId"></param>
    /// <returns></returns>
    public Task<AnswerViewModel[]> GetAnswersAsync(Guid questionId);

    /// <summary>
    /// Принять ответ за решение
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
