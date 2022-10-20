using System;
using TimeLogger.AppService.Contract.Tasks;

namespace TimeLogger.AppService.Contract.Logs
{
    public class LogView
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public Status Status { get; set; }
        public int EstimatedTimeMinutes { get; set; }
        public int TaskId { get; set; }

        public TaskView? Task { get; set; } = null!;
    }
}