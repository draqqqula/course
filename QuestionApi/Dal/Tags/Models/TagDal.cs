using Dal.Questions.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dal.Tags.Models;

/// <summary>
/// Отражение модели тега из хранилища данных
/// </summary>
[Index(nameof(Text))]
public record class TagDal
{
    /// <summary>
    /// Текст тега
    /// </summary>
    [Key]
    public required string Text { get; init; }

    /// <summary>
    /// Вопросы, помеченные тегом
    /// </summary>
    public virtual List<QuestionDal> Questions { get; } = [];
}
