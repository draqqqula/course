namespace Services.Interfaces;

public interface IIncreaceCounter
{
    public Task<Guid?> IncreaceCounterAsync(Guid id, int amount);
}
