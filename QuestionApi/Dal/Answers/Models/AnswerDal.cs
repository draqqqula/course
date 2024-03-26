using Core.Dal.Base;
using Dal.Authors.Models;
using Dal.Questions.Models;

namespace Dal.Answers.Models;

/// <summary>
/// Отражение модели ответа из хранилища данных
/// </summary>
public record class AnswerDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Текст ответа
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Автор ответа
    /// </summary>
    public virtual required AuthorDal Author { get; init; }

    /// <summary>
    /// Вопрос, на который сделан ответ
    /// </summary>
    public virtual required QuestionDal Question { get; init; }
}
