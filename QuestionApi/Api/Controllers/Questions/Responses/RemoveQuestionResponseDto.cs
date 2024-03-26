namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Ответ на запрос на удаление вопроса
/// </summary>
public record RemoveQuestionResponseDto
{
    public Guid? QuestionId { get; init; }
}
