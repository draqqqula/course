namespace Api.Controllers.Answers.Requests;

/// <summary>
/// Запрос на принятие ответа в качестве решения
/// </summary>
public record AcceptSolutionRequestDto
{
    public required Guid AnswerId { get; init; }
}
