using Abioka.Queue.Common;

namespace Abioka.Queue.Receiver.Abstractions
{
    internal interface IQueueConsumer
    {
        void Consume(IQueueConnection queueConnection);
    }
}