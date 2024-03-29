using Logic.Answers.ViewModels;

namespace Api.Controllers.Answers.Responses;

/// <summary>
/// Представление ответа на вопрос
/// </summary>
public record AnswerDto
{
    /// <summary>
    /// Содержимый текст ответа
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Уникальный идентификатор ответа
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Имя автора ответа
    /// </summary>
    public required string AuthorName { get; init; }

    /// <summary>
    /// Уникальный идентификатор автора ответа
    /// </summary>
    public required Guid AuthorId { get; init; }

    /// <summary>
    /// Время создания
    /// </summary>
    public required DateTime CreationTime { get; init; }

    public static explicit operator AnswerDto(AnswerViewModel viewModel)
    {
        return new AnswerDto()
        {
            AuthorId = viewModel.AuthorId,
            Id = viewModel.Id,
            Text = viewModel.Text,
            AuthorName = viewModel.AuthorName,
            CreationTime = viewModel.CreationTime,
        };
    }
}
