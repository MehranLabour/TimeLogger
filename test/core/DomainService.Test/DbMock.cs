using System.Collections.Generic;
using TimeLogger.Model.Projects;

namespace DomainService.Test
{
    public class DbMock
    {
        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
    }
}