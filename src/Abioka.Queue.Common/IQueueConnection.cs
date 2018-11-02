using RabbitMQ.Client;

namespace Abioka.Queue.Common
{
    public interface IQueueConnection
    {
        IConnection Connection { get; }
    }
}