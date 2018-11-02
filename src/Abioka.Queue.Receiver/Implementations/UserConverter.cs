using Abioka.Queue.Common.Entities;
using Abioka.Queue.Receiver.Abstractions;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class UserConverter : IUserConverter
    {
        private readonly IExceptionSender exceptionSender;

        public UserConverter(IExceptionSender exceptionSender) {
            this.exceptionSender = exceptionSender;
        }

        public User GetUser(byte[] data) {
            var message = Encoding.UTF8.GetString(data);
            Console.WriteLine(message);
            try {
                return JsonConvert.DeserializeObject<User>(message);
            } catch (Exception ex) {
                exceptionSender.Send($"Error on deserializing. Message: {message}. Exception:{ex}");
                return null;
            }
        }
    }
}
