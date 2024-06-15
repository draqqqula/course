using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProfileConnectionLib.ConnectionServices.DtoModels.GetUserInfo;

public record GetProfileRequest
{
    public required Guid Id { get; init; }
}
