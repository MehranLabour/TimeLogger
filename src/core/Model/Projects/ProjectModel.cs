using System;
using System.Collections.Generic;
using TimeLogger.Model.Tasks;

namespace TimeLogger.Model.Projects
{
    public class ProjectModel : BaseEntity<int>
    {
        
        public string Name { get; set; } = null!;
        public decimal? PricePerHour { get; set; }
        public DateTime DeadlineTime { get; set; }

        public List<TaskModel>? Tasks { get; set; }
    }
}