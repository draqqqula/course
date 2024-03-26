namespace Api.Controllers.Answers.Responses;

/// <summary>
/// Ответ на запрос на удаление ответа
/// </summary>
public record RemoveAnswerResponseDto
{
    public required Guid? AnswerId { get; init; }
}
