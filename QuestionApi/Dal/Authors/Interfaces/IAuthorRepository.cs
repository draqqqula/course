using Dal.Authors.Models;

namespace Dal.Authors.Interfaces;

/// <summary>
/// Хранение автора
/// </summary>
public interface IAuthorRepository
{
    /// <summary>
    /// Получить по id
    /// </summary>
    /// <param name="authorId"></param>
    /// <returns></returns>
    Task<AuthorDal> GetInfoAsync(Guid authorId);

    /// <summary>
    /// Создать автора
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(AuthorDal author);
}
