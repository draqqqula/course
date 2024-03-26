namespace Api.Controllers.Answers.Responses;

/// <summary>
/// Ответ на запрос на публикацию ответа
/// </summary>
public record PublishAnswerResponseDto
{
    public required Guid Id { get; init; }
}
