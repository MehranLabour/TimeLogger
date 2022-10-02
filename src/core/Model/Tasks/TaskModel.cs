using System;
using System.Collections.Generic;
using System.Text;
using TimeLogger.Model.Logs;
using TimeLogger.Model.Projects;

namespace TimeLogger.Model.Tasks
{
    public class TaskModel : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public int EstimatedTimeMinutes { get; set; }
        public int ProjectId { get; set; }
        public ProjectModel? ProjectModel { get; set; } = null!;
        public List<LogModel>? Logs { get; set; } = null!;
    }
}
