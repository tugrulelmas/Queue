using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;
using System.Threading.Tasks;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class StatusConsumer : IConsumer
    {
        public Task ConsumeAsync(User user) {
            // TODO: implement
            return Task.CompletedTask;
        }
    }
}
