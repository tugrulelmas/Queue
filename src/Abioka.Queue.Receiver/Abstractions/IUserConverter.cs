using Abioka.Queue.Common.Entities;

namespace Abioka.Queue.Receiver.Abstractions
{
    public interface IUserConverter
    {
        User GetUser(byte[] data);
    }
}