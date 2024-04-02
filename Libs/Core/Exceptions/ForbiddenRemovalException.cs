namespace Core.Exceptions;

/// <summary>
/// Исключение если нельзя удалить запись
/// </summary>
public class ForbiddenRemovalException : Exception
{
    public ForbiddenRemovalException(string? message) : base(message)
    {

    }
}
