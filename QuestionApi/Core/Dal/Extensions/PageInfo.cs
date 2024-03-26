namespace Core.Dal.Extensions;

public record PageInfo<T>
{
    public required int CurrentPage { get; init; }
    public required int TotalPages { get; init; }
    public required IQueryable<T> Collection { get; init; }
}
