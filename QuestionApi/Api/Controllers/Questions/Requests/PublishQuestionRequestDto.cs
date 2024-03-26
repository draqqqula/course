namespace Api.Controllers.Questions.Requests;

/// <summary>
/// Запрос на публикацию вопроса
/// </summary>
public record PublishQuestionRequestDto
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
    /// Теги вопроса
    /// </summary>
    public required string[] Tags { get; init; }

    /// <summary>
    /// Идентификатор вопроса
    /// </summary>
    public required Guid AuthorId { get; init; }
}
