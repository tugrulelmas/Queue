using System;

namespace Abioka.Queue.Common
{
    public static class Consts
    {
        public const string StatusExchange = "user.status.written";
        public const string StatusQueue = "user-status-updated-queue";
        public const string StatusRoutingKey = "user.event.status.updated";

        public const string StatusExceptionExchange = "user.status.exception";
        public const string StatusExceptionQueue = "user-status-exception-queue";
        public const string StatusExceptionRoutingKey = "user.event.status.exception";
        public const string StatusDuplicatedQueue = "user-status-duplicated-queue";
        public const string StatusDuplicatedRoutingKey = "user.event.status.duplicated";
    }
}
