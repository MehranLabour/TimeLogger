using System;
using System.Collections.Generic;
using TimeLogger.AppService.Contract.Tasks;

namespace TimeLogger.AppService.Contract.Projects
{
    public class ProjectView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? PricePerHour { get; set; }
        public DateTime DeadlineTime { get; set; }
        public Status Status { get; set; }

        public List<TaskView>? Tasks { get; set; }
    }
}