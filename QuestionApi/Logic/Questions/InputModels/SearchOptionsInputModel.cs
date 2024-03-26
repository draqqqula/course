namespace Logic.Questions.Models;

/// <summary>
/// Настройки для поиска по вопросам
/// </summary>
public record SearchOptionsInputModel
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    public required int Page { get; init; }

    /// <summary>
    /// Сколько записей должно быть на странице
    /// </summary>
    public required int PerPage { get; init; }

    /// <summary>
    /// Теги для поиска
    /// </summary>
    public required string[] Tags { get; init; }

    /// <summary>
    /// Показывать ли решённые
    /// </summary>
    public required bool ShowSolved { get; init; }

    /// <summary>
    /// Уникальный идентификатор автора
    /// </summary>
    public required Guid? AuthorId { get; init; }

    /// <summary>
    /// Дата с которой стоит начинать поиск
    /// </summary>
    public required DateTime? FromDate { get; init; }

    /// <summary>
    /// Дата, по которую стоит вести поиск
    /// </summary>
    public required DateTime? ToDate { get; init; }
}
