namespace Logic.Questions.Models;

/// <summary>
/// Модель для добавления вопроса
/// </summary>
public record QuestionInputModel
{
    /// <summary>
    /// Уникальный идентификатор автора
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
}
