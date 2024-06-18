namespace Logic.Authors.Models;

/// <summary>
/// Модель для добавления автора
/// </summary>
public record AuthorInputModel
{
    /// <summary>
    /// Имя автора
    /// </summary>
    public required Guid ProfileId { get; init; }
}
