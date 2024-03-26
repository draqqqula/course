using Logic.Questions.ViewModels;

namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Общее представление вопроса
/// </summary>
public record QuestionSummaryDto
{
    /// <summary>
    /// Заголовок вопроса
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Текст вопроса
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Имя автора вопроса
    /// </summary>
    public required string AuthorName { get; init; }

    /// <summary>
    /// Уникальный идентификатор автора вопроса
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
    /// Количество ответов
    /// </summary>
    public required int AnswerCount { get; init; }

    /// <summary>
    /// Есть ли решение
    /// </summary>
    public required bool Solved { get; init; }

    /// <summary>
    /// Теги
    /// </summary>
    public required string[] Tags { get; init; }

    public static explicit operator QuestionSummaryDto(QuestionSummaryViewModel summary)
    {
        return new QuestionSummaryDto()
        {
            AnswerCount = summary.AnswerCount,
            AuthorId = summary.AuthorId,
            CreationTime = summary.CreationTime,
            Title = summary.Title,
            Text = summary.Text,
            Tags = summary.Tags,
            Solved = summary.IsSolved,
            AuthorName = summary.AuthorName,
            Id = summary.QuestionId
        };
    }
}
