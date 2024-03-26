namespace Logic.Answers.ViewModels;

/// <summary>
/// Модель для получения информации об ответе
/// </summary>
public record AnswerViewModel
{
    /// <summary>
    /// Имя автора
    /// </summary>
    public required string AuthorName { get; init; }

    /// <summary>
    /// Текст ответа
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Уникальный идентификатор этого ответа
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Уникальный идентификатор автора
    /// </summary>
    public required Guid AuthorId { get; init; }
}
