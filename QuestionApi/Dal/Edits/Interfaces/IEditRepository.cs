using Dal.Edits.Models;

namespace Dal.Edits.Interfaces;

/// <summary>
/// Хранилище изменений вопросов
/// </summary>
public interface IEditRepository
{
    /// <summary>
    /// Добавить изменение
    /// </summary>
    /// <param name="dal"></param>
    /// <returns></returns>
    public Task<Guid> AddAsync(EditDal dal);
}
