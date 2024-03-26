namespace Core.Dal.Extensions;
using System.Linq;
using System.Linq.Expressions;
using System;

/// <summary>
/// Расширения для IQueryable
/// </summary>
public static class IQueryableExtensions
{
    /// <summary>
    /// Фильтрует коллекцию только если <paramref name="condition"/> вернёт true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="condition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> collection, 
        bool condition,
        Expression<Func<T, bool>> predicate)
    {
        if (condition)
        {
            return collection.Where(predicate);
        }
        return collection;
    }

    /// <summary>
    /// Фильтрует коллекцию только если <paramref name="nullable"/> будет не null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <param name="nullable"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IQueryable<T> WhereIfNotNull<T>(
        this IQueryable<T> collection,
        object? nullable,
        Expression<Func<T, bool>> predicate)
    {
        return collection.WhereIf(nullable is not null, predicate);
    }

    public static PageInfo<T> ToPageInfo<T>(
        this IQueryable<T> collection,
        int pageNumber,
        int perPage)
    {
        var total = collection.Count();
        if (pageNumber <= 0 || perPage <= 0)
        {
            return new PageInfo<T>()
            {
                CurrentPage = 0,
                TotalPages = 0,
                Collection = collection,
            };
        }
        var totalPages = (int)Math.Ceiling((double)total / perPage);
        var currentPage = Math.Clamp(pageNumber, 1, totalPages);
        var pages = collection
            .Skip((currentPage - 1) * perPage)
            .Take(perPage);
        return new PageInfo<T>()
        {
            CurrentPage = currentPage,
            TotalPages = totalPages,
            Collection = pages,
        };
    }
}
