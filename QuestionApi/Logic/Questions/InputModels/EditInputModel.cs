namespace Logic.Questions.Models;

/// <summary>
/// Модель для добавления изменения к вопросу
/// </summary>
public record EditInputModel
{
    /// <summary>
    /// Новый текст
    /// </summary>
    public required string Text { get; init; }
    
    /// <summary>
    /// Уникальный идентификатор вопроса
    /// </summary>
    public required Guid QuestionId { get; init; }
}
