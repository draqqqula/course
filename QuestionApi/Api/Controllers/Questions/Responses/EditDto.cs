using Logic.Questions.ViewModels;

namespace Api.Controllers.Questions.Responses;

/// <summary>
/// Представление одной итерации истории редактирования
/// </summary>
public class EditDto
{
    /// <summary>
    /// Текст
    /// </summary>
    public required string Text { get; init; }
    
    /// <summary>
    /// Время редактирвания
    /// </summary>
    public required DateTime PublishTime { get; init; }

    public static explicit operator EditDto(EditViewModel edit)
    {
        return new EditDto()
        {
            Text = edit.Text,
            PublishTime = edit.PublishTime
        };
    }
}
