using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class StatusConsumerRepeater : IConsumer
    {
        private readonly IConsumer consumer;
        private readonly IRepeater repeater;

        public StatusConsumerRepeater(IConsumer consumer, IRepeater repeater) {
            this.consumer = consumer;
            this.repeater = repeater;
        }

        public void Consume(User user) {
            repeater.Repeat(() => consumer.Consume(user), 3);
        }
    }
}