using Core.Logic.Connections.RabbitMQ.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic.Connections.RabbitMQ;

internal class RabbitMQChannelFactory : IRabbitMQChannelFactory
{
    private readonly IConnection _connection;

    public RabbitMQChannelFactory(IConfiguration configuration)
    {
        IConnectionFactory connectionFactory;
        if (configuration["RabbitMQConnectionType"] == "Uri")
        {
            connectionFactory = new ConnectionFactory() { Uri = configuration.GetValue<Uri>("AmqpUri") };
        }
        else
        {
            connectionFactory = new ConnectionFactory() { HostName = configuration.GetValue<string>("RabbitMQHostName") };
        }
        _connection = connectionFactory.CreateConnection();
    }

    public IModel Create()
    {
        return _connection.CreateModel();
    }
}
