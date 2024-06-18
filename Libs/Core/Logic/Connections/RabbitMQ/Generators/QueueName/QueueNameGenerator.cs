using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Connections.RabbitMQ.Generators.QueueName;

internal class QueueNameGenerator : IQueueNameGenerator
{
    public string GenerateForRequests<T>()
    {
        return typeof(T).Name;
    }

    public string GenerateForResponses()
    {
        return "Responses";
    }
}
