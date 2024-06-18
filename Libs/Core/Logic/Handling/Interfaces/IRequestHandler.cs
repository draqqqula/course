namespace Core.Logic.Handling.Interfaces;

public interface IRequestHandler<in TRequest, out TResponse>
{
    public TResponse Handle(TRequest request);
}
