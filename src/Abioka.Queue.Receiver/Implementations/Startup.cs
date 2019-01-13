using Abioka.Queue.Common;
using Abioka.Queue.Receiver.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class Startup : IStartup
    {
        private readonly IConfiguration configuration;
        private readonly IEnumerable<IQueueConsumer> consumers;

        public Startup(IConfiguration configuration, IEnumerable<IQueueConsumer> consumers) {
            this.configuration = configuration;
            this.consumers = consumers;
        }

        public void Start() {
            foreach (var consumerItem in consumers) {
                Task.Run(() => {
                    var queueConnection = new QueueConnection(configuration);
                    consumerItem.Consume(queueConnection);
                });
            }
        }
    }
}
