using Abioka.Queue.Common;
using Abioka.Queue.Receiver.Abstractions;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class ExceptionSender : IExceptionSender
    {
        private readonly ISender sender;

        public ExceptionSender(ISender sender) {
            this.sender = sender;
        }

        public void Send(byte[] data) {
            sender.Send(Consts.StatusExceptionExchange, Consts.StatusExceptionRoutingKey, data);
        }

        public void Send(object value) {
            sender.Send(Consts.StatusExceptionExchange, Consts.StatusExceptionRoutingKey, value);
        }
    }
}