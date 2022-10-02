using System.Collections.Generic;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.AppService.Contract.Projects;

namespace TimeLogger.AppService.Contract.Tasks
{
    public class TaskView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Status Status { get; set; }
        public int EstimatedTimeMinutes { get; set; }
        public int ProjectId { get; set; }

        public ProjectView? Project { get; set; } = null!;
        public List<LogView>? Logs { get; set; }
    }
}