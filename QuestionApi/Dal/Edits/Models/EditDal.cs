using Core.Dal.Base;
using Dal.Questions.Models;

namespace Dal.Edits.Models;

/// <summary>
/// Отражение модели изменения вопросов из хранилища данных
/// </summary>
public record EditDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Новый текст вопроса
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Время добавления изменения
    /// </summary>
    public required DateTime PublishTime { get; init; }

    /// <summary>
    /// Отредактированный вопрос
    /// </summary>
    public virtual required QuestionDal Question { get; init; }
}
