namespace Api.Controllers.Answers.Requests;

/// <summary>
/// Запрос на публикацию ответа
/// </summary>
public record PublishAnswerRequestDto
{
    public required Guid QuestionId { get; init; }
    public required string Text { get; init; }
    public required Guid AuthorId { get; init; }
}
