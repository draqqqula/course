using Core.Dal.Base;
using Dal.Answers.Models;
using Dal.Questions.Models;

namespace Dal.Authors.Models;

public record class AuthorDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Имя автора
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Вопросы, заданные автором
    /// </summary>
    public virtual List<QuestionDal> Questions { get; } = [];

    /// <summary>
    /// Ответы автора
    /// </summary>
    public virtual List<AnswerDal> Answers { get; } = [];
}
