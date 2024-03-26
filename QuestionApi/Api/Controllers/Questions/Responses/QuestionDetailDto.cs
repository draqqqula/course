using Logic.Questions.ViewModels;

namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Детальное представление вопроса
/// </summary>
public record QuestionDetailDto
{
    /// <summary>
    /// Заголовок вопроса
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Оригинальный текст вопроса
    /// </summary>
    public required string OriginalText { get; init; }
    
    /// <summary>
    /// Имя автора вопроса
    /// </summary>
    public required string AuthorName { get; init; }

    /// <summary>
    /// Идентификатор автора вопроса
    /// </summary>
    public required Guid AuthorId { get; init; }

    /// <summary>
    /// Дата создания вопроса
    /// </summary>
    public required DateTime CreationTime { get; init; }

    /// <summary>
    /// Уникальный идентификатор вопроса
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Теги
    /// </summary>
    public required string[] Tags { get; init; }
    
    /// <summary>
    /// История изменений
    /// </summary>
    public required EditDto[] Edits { get; init; }

    public static explicit operator QuestionDetailDto(QuestionDetailViewModel summary)
    {
        return new QuestionDetailDto()
        {
            AuthorId = summary.AuthorId,
            CreationTime = summary.CreationTime,
            Title = summary.Title,
            OriginalText = summary.Text,
            Tags = summary.Tags,
            AuthorName = summary.AuthorName,
            Id = summary.QuestionId,
            Edits = summary.Edits.Select(it => (EditDto)it).ToArray()
        };
    }
}