using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.Model.Tasks;

namespace TimeLogger.Model.Logs
{
    public class LogModel : BaseEntity<int>
    {
        public string? Description { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public int EstimatedTimeMinutes { get; set; }
        public int TaskId { get; set; }
        public TaskModel? Task { get; set; } = null!;
    }
}

