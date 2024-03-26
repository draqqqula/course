namespace Api.Controllers.Questions.Requests;

/// <summary>
/// Запрос на удаление вопроса
/// </summary>
public record RemoveQuestionRequestDto
{
    /// <summary>
    /// Идентификатор вопроса
    /// </summary>
    public required Guid QuestionId { get; init; }
}
