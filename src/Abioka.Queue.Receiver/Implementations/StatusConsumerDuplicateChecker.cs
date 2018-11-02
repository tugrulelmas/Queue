using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;

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

        public void Consume(User user) {
            var isAlreadyConsumed = false; // TODO: implement real checker
            if (isAlreadyConsumed) {
                duplicateSender.Send(user);
                return;
            }

            consumer.Consume(user);
        }
    }
}
