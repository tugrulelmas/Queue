using Abioka.Queue.Common;
using Abioka.Queue.Receiver.Abstractions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class StatusQueueConsumer : IQueueConsumer
    {
        private readonly IUserConverter userConverter;
        private readonly IConsumer consumer;

        public StatusQueueConsumer(IUserConverter userConverter, IConsumer consumer) {
            this.userConverter = userConverter;
            this.consumer = consumer;
        }

        public void Consume(IQueueConnection queueConnection) {
            using (var model = queueConnection.Connection.CreateModel()) {
                var consumer = new EventingBasicConsumer(model);
                model.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                consumer.Received += async (receivedModel, ea) => {
                    var user = userConverter.GetUser(ea.Body);
                    if (user != null) {
                        await this.consumer.ConsumeAsync(user);
                    }

                    model.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };

                model.BasicConsume(queue: Consts.StatusQueue, autoAck: false, consumer: consumer);

                while (true){}
            }
        }
    }
}