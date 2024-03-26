namespace Api.Controllers.Answers.Responses;

/// <summary>
/// Ответ на запрос принятие ответа в качестве решения
/// </summary>
public record AcceptSolutionResponseDto
{
    public required Guid? AnswerId { get; init; }
}
