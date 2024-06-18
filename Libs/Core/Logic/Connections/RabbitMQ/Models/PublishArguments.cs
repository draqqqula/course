using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Connections.RabbitMQ.Models;

public record PublishArguments
{
    public required IBasicProperties Properties { get; init; }
    public required string ExchangeName { get; init; }
    public required string RoutingKey { get; init; }
}
