using Abioka.Queue.Receiver.Abstractions;
using System.Collections.Generic;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class Startup : IStartup
    {
        private readonly IEnumerable<IQueueConsumer> consumers;
        private readonly IRepeater repeater;

        public Startup(IEnumerable<IQueueConsumer> consumers, IRepeater repeater) {
            this.consumers = consumers;
            this.repeater = repeater;
        }

        public void Start() {
            repeater.Repeat(() =>{
            foreach (var consumerItem in consumers) {
                consumerItem.Consume();
            }}, 3);
        }
    }
}
