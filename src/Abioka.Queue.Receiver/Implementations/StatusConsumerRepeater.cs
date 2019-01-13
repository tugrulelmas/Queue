using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;
using System.Threading.Tasks;

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

        public async Task ConsumeAsync(User user) {
            await repeater.RepeatAsync(async () => await consumer.ConsumeAsync(user), 3);
        }
    }
}