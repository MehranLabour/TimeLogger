using System;
using TimeLogger.AppService.Contract;

namespace TimeLogger.Model
{
    public abstract class BaseEntity<TKey>
    {
        public BaseEntity()
        {
            Status = Status.Pending;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public TKey Id { get; set; } = default!;
        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}