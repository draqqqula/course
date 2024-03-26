using Dal.Questions.Models;

namespace Logic.Questions.ViewModels;

/// <summary>
/// Модель для получения общей информации о вопросе
/// </summary>
public record QuestionSummaryViewModel
{
    /// <summary>
    /// Уникальный идентификактор вопроса
    /// </summary>
    public required Guid QuestionId { get; init; }

    /// <summary>
    /// Уникальный идентификатор автора вопроса
    /// </summary>
    public required Guid AuthorId { get; init; }

    /// <summary>
    /// Заголовок вопроса
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Текст вопроса
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Теги вопроса
    /// </summary>
    public required string[] Tags { get; init; }

    /// <summary>
    /// Дата публикации вопроса
    /// </summary>
    public required DateTime CreationTime { get; init; }

    /// <summary>
    /// Решен ли вопрос
    /// </summary>
    public required bool IsSolved { get; init; }

    /// <summary>
    /// Имя автора
    /// </summary>
    public required string AuthorName { get; init; }

    /// <summary>
    /// Число ответов
    /// </summary>
    public required int AnswerCount { get; init; }


    public static explicit operator QuestionSummaryViewModel(QuestionDal dal)
    {
        var summary = new QuestionSummaryViewModel()
        {
            AuthorId = dal.Author.Id,
            AnswerCount = dal.Answers.Count,
            Text = dal.Edits.MaxBy(it => it.PublishTime)?.Text ?? dal.Text,
            Title = dal.Title,
            Tags = dal.Tags.Select(it => it.Text).ToArray(),
            CreationTime = dal.CreationTime,
            IsSolved = dal.SolutionId is not null,
            AuthorName = dal.Author.Name,
            QuestionId = dal.Id
        };
        return summary;
    }
}
