namespace Abioka.Queue.Receiver.Abstractions
{
    public interface IExceptionSender
    {
        void Send(byte[] data);

        void Send(object value);
    }
}