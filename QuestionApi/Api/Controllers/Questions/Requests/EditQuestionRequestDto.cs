namespace Api.Controllers.Questions.Requests;

/// <summary>
/// Запрос на редактирование вопроса
/// </summary>
public record EditQuestionRequestDto
{
    public required Guid QuestionId { get; init; }

    public required string Text { get; init; }
}
