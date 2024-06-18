namespace Core.Logic.Handling.Interfaces;

public interface IAsyncRequestHandler<in TRequest, TResponse>
{
    public Task<TResponse> HandleAsync(TRequest request);
}
