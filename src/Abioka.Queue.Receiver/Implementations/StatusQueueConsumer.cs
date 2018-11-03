using Abioka.Queue.Common;
using Abioka.Queue.Receiver.Abstractions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class StatusQueueConsumer : IQueueConsumer
    {
        private readonly IQueueConnection queueConnection;
        private readonly IUserConverter userConverter;
        private readonly IConsumer consumer;

        public StatusQueueConsumer(IQueueConnection queueConnection, IUserConverter userConverter, IConsumer consumer) {
            this.queueConnection = queueConnection;
            this.userConverter = userConverter;
            this.consumer = consumer;
        }

        public void Consume() {
            Console.WriteLine("before creating model");
            using (var model = queueConnection.Connection.CreateModel()) {
                Console.WriteLine("after creating model");
                var consumer = new EventingBasicConsumer(model);
                model.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                consumer.Received += (receivedModel, ea) => {
                    var user = userConverter.GetUser(ea.Body);
                    if (user != null) {
                        this.consumer.Consume(user);
                    }

                    model.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                model.BasicConsume(queue: Consts.StatusQueue, autoAck: false, consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}