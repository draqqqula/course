using Core.Dal.Base;

namespace Domain.Entities;

public record Profile : BaseEntityDal<Guid>
{
    public required string Name { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required string Description { get; init; }
    public uint AskedCount { get; set; } = 0;
    public uint AnsweredCount { get; set; } = 0;
    public uint SolvedCount { get; set; } = 0;
    public int Reputation { get; set; } = 0;
}
