using Abioka.Queue.Common;
using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class DuplicateSender : IDuplicateSender
    {
        private readonly ISender sender;

        public DuplicateSender(ISender sender) {
            this.sender = sender;
        }

        public void Send(User user) {
            sender.Send(Consts.StatusExceptionExchange, Consts.StatusDuplicatedRoutingKey, user);
        }
    }
}