namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Ответ на запрос на редактирование вопроса
/// </summary>
public record EditQuestionResponseDto
{
    public required Guid Id { get; init; }
}
