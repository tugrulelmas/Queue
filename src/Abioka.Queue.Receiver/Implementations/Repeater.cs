using Abioka.Queue.Receiver.Abstractions;
using System;
using System.Threading;

namespace Abioka.Queue.Receiver.Implementations
{
    internal class Repeater : IRepeater
    {
        private readonly IExceptionSender exceptionSender;

        public Repeater(IExceptionSender exceptionSender) {
            this.exceptionSender = exceptionSender;
        }

        public void Repeat(Action action, int times) {
            var tryCount = 0;
            while (true) {
                try {
                    tryCount++;
                    action();
                    break;
                } catch (Exception ex) {
                    if (tryCount == times + 1) {
                        exceptionSender.Send(ex);
                        break;
                    }

                    Thread.Sleep(1000 * (int)Math.Pow(4, tryCount));
                }
            }
        }
    }
}