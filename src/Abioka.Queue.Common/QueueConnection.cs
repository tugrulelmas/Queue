using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;

namespace Abioka.Queue.Common
{
    public class QueueConnection : IQueueConnection
    {
        public QueueConnection(IConfiguration configuration) {
            var hostName = configuration.GetValue<string>("QueueHostName");
            var hostNameAndPort = hostName.Split(':');
            var factory = new ConnectionFactory() {
                HostName = hostNameAndPort[0],
                Port = Convert.ToInt32(hostNameAndPort[1]),
                UserName = configuration.GetValue<string>("QueueUserName"),
                Password = configuration.GetValue<string>("QueuePassword"),
            };
            Console.WriteLine($"HostName: {hostName}");
            Console.WriteLine($"QueueUserName: {factory.UserName}");
            Console.WriteLine($"QueuePassword: {factory.Password}");

            Connection = factory.CreateConnection();
            using (var model = Connection.CreateModel()) {
                DeclareExcnhageAndQueues(model);
                Console.WriteLine("success");
            }
        }

        public IConnection Connection { get; }

        private static void DeclareExcnhageAndQueues(IModel model) {
            model.ExchangeDeclare(exchange: Consts.StatusExchange, type: "direct");
            model.ExchangeDeclare(exchange: Consts.StatusExceptionExchange, type: "direct");

            model.QueueDeclare(queue: Consts.StatusQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            model.QueueDeclare(queue: Consts.StatusExceptionQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            model.QueueDeclare(queue: Consts.StatusDuplicatedQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            model.QueueBind(queue: Consts.StatusQueue, exchange: Consts.StatusExchange, routingKey: Consts.StatusRoutingKey);
            model.QueueBind(queue: Consts.StatusExceptionQueue, exchange: Consts.StatusExceptionExchange, routingKey: Consts.StatusExceptionRoutingKey);
            model.QueueBind(queue: Consts.StatusDuplicatedQueue, exchange: Consts.StatusExceptionExchange, routingKey: Consts.StatusDuplicatedRoutingKey);
        }
    }
}