using Logic.Authors.Models;

namespace Logic.Authors.Interfaces;

/// <summary>
/// Работа с авторами
/// </summary>
public interface IAuthorLogicManager
{
    /// <summary>
    /// Создать автора
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    public Task<Guid> CreateAsync(AuthorInputModel author);
}
