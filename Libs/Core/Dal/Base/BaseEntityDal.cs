namespace Core.Dal.Base;

/// <summary>
/// Базовая сущность для работы с сущностями в бд
/// </summary>
/// <typeparam name="T">тип идентификатор</typeparam>
public abstract record BaseEntityDal<T>
{
    /// <summary>
    /// уникальный идентфиикатор сущности
    /// </summary>
    public T Id { get; init; }
}
