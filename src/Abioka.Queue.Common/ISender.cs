using System.Collections.Generic;

namespace Abioka.Queue.Common
{
    public interface ISender
    {
        void Send(string exchange, string routingKey, byte[] data);

        void Send<T>(string exchange, string routingKey, T value);

        void Send<T>(string exchange, string routingKey, IEnumerable<T> value);
    }
}