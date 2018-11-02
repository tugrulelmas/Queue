using Abioka.Queue.Receiver.Abstractions;
using System.Collections.Generic;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class Startup : IStartup
    {
        private readonly IEnumerable<IQueueConsumer> consumers;

        public Startup(IEnumerable<IQueueConsumer> consumers) {
            this.consumers = consumers;
        }

        public void Start() {
            foreach (var consumerItem in consumers) {
                consumerItem.Consume();
            }
        }
    }
}
