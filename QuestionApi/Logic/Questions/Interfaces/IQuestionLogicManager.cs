using Logic.Questions.Models;
using Logic.Questions.ViewModels;

namespace Logic.Questions.Interfaces;

/// <summary>
/// Управление вопросами
/// </summary>
public interface IQuestionLogicManager
{
    /// <summary>
    /// Опубликовать вопрос
    /// </summary>
    /// <param name="question"></param>
    /// <returns></returns>
    public Task<Guid> PublishAsync(QuestionInputModel question);

    /// <summary>
    /// Поиск по вопросам
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public Task<SearchResultViewModel> SearchAsync(SearchOptionsInputModel options);

    /// <summary>
    /// Получить детали вопроса
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<QuestionDetailViewModel> GetInfoAsync(Guid Id);

    /// <summary>
    /// Удалить вопрос
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Guid?> RemoveAsync(Guid id);

    /// <summary>
    /// Отредактировать вопрос
    /// </summary>
    /// <param name="edit"></param>
    /// <returns></returns>
    public Task<Guid> EditAsync(EditInputModel edit);
}
