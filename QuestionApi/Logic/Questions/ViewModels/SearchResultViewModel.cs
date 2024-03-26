namespace Logic.Questions.ViewModels;

/// <summary>
/// Модель для получения информации о результатах поиска
/// </summary>
public record SearchResultViewModel
{
    /// <summary>
    /// Результаты поиска
    /// </summary>
    public required QuestionSummaryViewModel[] Questions { get; init; }

    /// <summary>
    /// Текущая страница
    /// </summary>
    public required int CurrentPage { get; init; }

    /// <summary>
    /// Всего страниц
    /// </summary>
    public required int TotalPages { get; init; }
}
