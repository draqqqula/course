namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Ответ на запрос на публикацию ответа
/// </summary>
public record PublishQuestionResponseDto
{
    public required Guid Id { get; set; }
}
