using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;

public record CheckUserExistsProfileApiResponse
{
    public required Guid? Id { get; init; }
}
