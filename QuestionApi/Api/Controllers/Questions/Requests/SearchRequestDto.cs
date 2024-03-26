using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Questions.Requests;

/// <summary>
/// Запрос на поиск по вопросам
/// </summary>
public record SearchRequestDto
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    [Range(0, int.MaxValue)]
    public required int Page { get; init; } = 0;

    /// <summary>
    /// Всего страниц
    /// </summary>
    [Range(0, 32)]
    public required int PerPage { get; init; } = 10;

    /// <summary>
    /// Искомые теги
    /// </summary>
    public required string[] Tags { get; init; }

    /// <summary>
    /// Показывать ли решённые
    /// </summary>
    public required bool ShowSolved { get; init; } = true;

    /// <summary>
    /// Пользователь, от которого искать вопросы
    /// </summary>
    public required Guid? FromUser { get; init; } = null;

    /// <summary>
    /// Искать с этой даты
    /// </summary>
    public required DateTime? FromDate { get; init; } = null;

    /// <summary>
    /// Искать по эту дату
    /// </summary>
    public required DateTime? ToDate { get; init; } = null;
}
