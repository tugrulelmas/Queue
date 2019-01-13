using Abioka.Queue.Common.Entities;
using System.Threading.Tasks;

namespace Abioka.Queue.Receiver.Abstractions
{
    public interface IConsumer
    {
        Task ConsumeAsync(User user);
    }
}
