using Api.Controllers.Questions.Responses;

namespace Api.Controllers.Answers.Responses;

/// <summary>
/// Представление дискуссии
/// </summary>
public record DiscussionDto
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public required QuestionDetailDto Question { get; init; }

    /// <summary>
    /// Решение
    /// </summary>
    public required AnswerDto? Solution { get; init; }

    /// <summary>
    /// Ответы
    /// </summary>
    public required AnswerDto[] Answers { get; init; }
}
