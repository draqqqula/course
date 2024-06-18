using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;

public record GetProfileResponse
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required int Reputation { get; init; }
    public required uint AskedCount { get; init; }
    public required uint AnsweredCount { get; init; }
    public required uint SolvedCount { get; init; }
}
