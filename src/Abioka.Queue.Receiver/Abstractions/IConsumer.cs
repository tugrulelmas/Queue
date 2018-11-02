using Abioka.Queue.Common.Entities;

namespace Abioka.Queue.Receiver.Abstractions
{
    public interface IConsumer
    {
        void Consume(User user);
    }
}
