using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Connections.RabbitMQ.Generators.CorrelationId;

internal class CorrelationIdGenerator : ICorrelationIdGenerator
{
    public string Generate()
    {
        return Guid.NewGuid().ToString();
    }
}
