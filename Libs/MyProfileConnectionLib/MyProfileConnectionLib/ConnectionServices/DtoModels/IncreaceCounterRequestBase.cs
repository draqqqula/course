using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProfileConnectionLib.ConnectionServices.DtoModels;

public abstract record IncreaceCounterRequestBase
{
    public required Guid Id { get; init; }
    public required int Amount { get; init; }
}
