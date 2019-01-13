using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;
using System.Threading.Tasks;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class StatusConsumerDuplicateChecker : IConsumer
    {
        private readonly IConsumer consumer;
        private readonly IDuplicateSender duplicateSender;

        public StatusConsumerDuplicateChecker(IConsumer consumer, IDuplicateSender duplicateSender) {
            this.consumer = consumer;
            this.duplicateSender = duplicateSender;
        }

        public async Task ConsumeAsync(User user) {
            var isAlreadyConsumed = false; // TODO: implement real checker
            if (isAlreadyConsumed) {
                duplicateSender.Send(user);
                return;
            }

            await consumer.ConsumeAsync(user);
        }
    }
}
