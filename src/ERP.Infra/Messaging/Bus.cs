using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace ERP.Infra.Messaging
{
    public class Bus : IBus
    {
        private readonly IConfiguration _configuration;

        public Bus(IConfiguration configuration) => _configuration = configuration;

        public void Publish(string message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(_configuration["ApplicationOptions:RabbitMQConnection"]!);
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var exchangeName = "external_bus";
            var queueName = $"api_to_server_external_bus";
            var routingKey = "api_to_server";

            channel.ExchangeDeclare(exchange: exchangeName,
                type: "direct",
                durable: false,
                autoDelete: false,
                arguments: null);

            channel.QueueDeclare(queue: queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

            channel.QueueBind(queue: queueName,
                exchange: exchangeName,
                routingKey: routingKey,
                arguments: null);

            channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
        }
    }
}