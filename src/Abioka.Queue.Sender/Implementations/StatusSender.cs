using Abioka.Queue.Common;
using Abioka.Queue.Common.Entities;
using Abioka.Queue.Sender.Abstractions;
using System.Collections.Generic;

namespace Abioka.Queue.Sender.Implementations
{
    internal class StatusSender : IEventSender
    {
        private readonly ISender sender;

        public StatusSender(ISender sender) {
            this.sender = sender;
        }

        public void Send(IEnumerable<User> users) {
            sender.Send(Consts.StatusExchange, Consts.StatusRoutingKey, users);
        }
    }
}