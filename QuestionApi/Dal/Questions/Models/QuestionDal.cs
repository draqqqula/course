using Core.Dal.Base;
using Dal.Answers.Models;
using Dal.Authors.Models;
using Dal.Edits.Models;
using Dal.Tags.Models;

namespace Dal.Questions.Models;

/// <summary>
/// Отражение модели вопроса из хранилища данных
/// </summary>
public record class QuestionDal : BaseEntityDal<Guid>
{
    /// <summary>
    /// Заголовок вопроса
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Текст вопроса
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// Автор вопроса
    /// </summary>
    public virtual required AuthorDal Author { get; init; }

    /// <summary>
    /// Время публикации вопроса
    /// </summary>
    public required DateTime CreationTime { get; init; }

    /// <summary>
    /// Ответы на вопрос
    /// </summary>
    public virtual List<AnswerDal> Answers { get; } = [];

    /// <summary>
    /// Теги вопроса
    /// </summary>
    public virtual required List<TagDal> Tags { get; init; } = [];

    /// <summary>
    /// Id решения
    /// </summary>
    public Guid? SolutionId { get; set; } = null;

    /// <summary>
    /// История изменений
    /// </summary>
    public virtual List<EditDal> Edits { get; } = [];
} 
