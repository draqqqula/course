using Logic.Questions.ViewModels;

namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Ответ на запрос на поиск по вопросам
/// </summary>
public record SearchResponseDto
{
    /// <summary>
    /// Текущая страница
    /// </summary>
    public required int CurrentPage { get; init; }

    /// <summary>
    /// Всего страниц
    /// </summary>
    public required int TotalPages { get; init; }

    /// <summary>
    /// Результат поиска
    /// </summary>
    public required QuestionSummaryDto[] Positions { get; init; }

    public static explicit operator SearchResponseDto(SearchResultViewModel result)
    {
        return new SearchResponseDto()
        {
            Positions = result.Questions.Select(it => (QuestionSummaryDto)it).ToArray(),
            CurrentPage = result.CurrentPage,
            TotalPages = result.TotalPages
        };
    }
}
