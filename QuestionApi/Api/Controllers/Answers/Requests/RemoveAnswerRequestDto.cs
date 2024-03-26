namespace Api.Controllers.Answers.Requests;

/// <summary>
/// Запрос на удаление ответа
/// </summary>
public record RemoveAnswerRequestDto
{
    public required Guid AnswerId { get; init; }
}
