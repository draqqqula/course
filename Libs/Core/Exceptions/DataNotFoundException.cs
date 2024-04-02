namespace Core.Exceptions;

/// <summary>
/// Исключение если запись по запросу не найдена
/// </summary>
public class DataNotFoundException : Exception
{
    public DataNotFoundException(string? message) : base(message)
    {
    }
}
