using Abioka.Queue.Common.Entities;

namespace Abioka.Queue.Receiver.Abstractions
{
    public interface IDuplicateSender
    {
        void Send(User user);
    }
}