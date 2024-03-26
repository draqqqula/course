using Dal.Questions.Models;

namespace Logic.Questions.ViewModels;

/// <summary>
/// Модель для получения детальной информации о вопросе
/// </summary>
public record QuestionDetailViewModel
{
    /// <summary>
    /// Уникальный идентифиактор вопроса
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
    /// Дата создания вопроса
    /// </summary>
    public required DateTime CreationTime { get; init; }

    /// <summary>
    /// Имя автора вопроса
    /// </summary>
    public required string AuthorName { get; init; }

    /// <summary>
    /// Идентифиактор принятого решения
    /// </summary>
    public required Guid? SolutionId { get; init; }

    /// <summary>
    /// История изменений
    /// </summary>
    public required EditViewModel[] Edits { get; init; }


    public static explicit operator QuestionDetailViewModel(QuestionDal dal)
    {
        var summary = new QuestionDetailViewModel()
        {
            AuthorId = dal.Author.Id,
            Text = dal.Text,
            Title = dal.Title,
            Tags = dal.Tags.Select(it => it.Text).ToArray(),
            CreationTime = dal.CreationTime,
            SolutionId = dal.SolutionId,
            AuthorName = dal.Author.Name,
            QuestionId = dal.Id,
            Edits = dal.Edits.Select(it => (EditViewModel)it).ToArray()
        };
        return summary;
    }
}
