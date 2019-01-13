using System;
using System.Threading.Tasks;

namespace Abioka.Queue.Receiver.Abstractions
{
    internal interface IRepeater
    {
        /// <summary>
        /// Repeats the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="times">The times.</param>
        Task RepeatAsync(Func<Task> action, int times);
    }
}
