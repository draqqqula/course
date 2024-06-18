namespace Api.Listeners.Models;

public record GetProfileRequest
{
    public required Guid Id { get; init; }
}
