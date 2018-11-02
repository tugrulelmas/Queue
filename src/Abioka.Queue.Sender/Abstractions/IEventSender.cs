using Abioka.Queue.Common.Entities;
using System.Collections.Generic;

namespace Abioka.Queue.Sender.Abstractions
{
    public interface IEventSender
    {
        /// <summary>
        /// Sends the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        void Send(IEnumerable<User> users);
    }
}