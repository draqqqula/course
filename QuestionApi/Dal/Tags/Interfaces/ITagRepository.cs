using Dal.Tags.Models;

namespace Dal.Tags.Interfaces;

/// <summary>
/// Хранилище тегов
/// </summary>
public interface ITagRepository
{
    /// <summary>
    /// Добавить новые теги
    /// </summary>
    /// <param name="tags"></param>
    /// <returns></returns>
    public Task AddRangeAsync(TagDal[] tags);

    /// <summary>
    /// Получить по тексту
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Task<TagDal?> FindTagAsync(string text);
}
