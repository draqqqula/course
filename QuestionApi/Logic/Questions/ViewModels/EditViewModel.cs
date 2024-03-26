using Dal.Edits.Models;

namespace Logic.Questions.ViewModels;

/// <summary>
/// Модель для получения информации об изменении
/// </summary>
public class EditViewModel
{
    /// <summary>
    /// Новый текст
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Дата редактирования
    /// </summary>
    public required DateTime PublishTime { get; init; }

    public static explicit operator EditViewModel(EditDal dal)
    {
        return new EditViewModel()
        {
            PublishTime = dal.PublishTime,
            Text = dal.Text
        };
    }
}
