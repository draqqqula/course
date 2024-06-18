using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProfileConnectionLib.ConnectionServices.DtoModels.CreateUser;

public record CreateUserProfileResponse
{
    public required Guid? Id { get; init; }
}
