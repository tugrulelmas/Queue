using System;

namespace Abioka.Queue.Common.Entities
{
    public class User
    {
        public User() {
            UpdatedDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public UserStatus UserStatus { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
