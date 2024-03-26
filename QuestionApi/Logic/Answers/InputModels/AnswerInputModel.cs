namespace Logic.Answers.Models;

/// <summary>
/// Модель для добавления ответа
/// </summary>
public record AnswerInputModel
{
    /// <summary>
    /// Уникальный идентификатор автора
    /// </summary>
    public required Guid AuthorId { get; init; }

    /// <summary>
    /// Уникальный идентификатор вопроса
    /// </summary>
    public required Guid QuestionId { get; init; }

    /// <summary>
    /// Текст ответа
    /// </summary>
    public required string Text { get; init; }
}
