using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.DomainService.Projects;
using TimeLogger.Model.Projects;
using TimeLogger.Model.Tasks;

namespace TimeLogger.AppService.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectDomain _domain;

        public ProjectService(IProjectDomain domain)
        {
            _domain = domain;
        }

        public async Task<ProjectView> Add(ProjectView projectView)
        {
            await ValidateAndThrowException(projectView);
            var project = ToProject(projectView);
            var projectModel = await _domain.Add(project);
            return ToProjectView(projectModel);
        }

        public async Task<ProjectView> Update(ProjectView projectView)
        {
            var project = await _domain.Update(ToProject(projectView));
            return ToProjectView(project);
        }

        public async Task<List<ProjectView>> GetByName(string projectName, Paging paging)
        {
            var projects = await _domain.GetByName(projectName, paging);
            return projects.Select(ToProjectView).ToList();
        }

        public async Task<ProjectView?> FindById(int id)
        {
            var project = await _domain.FindById(id);
            return project == null ? null : ToProjectView(project);
        }

        public async Task<bool> Delete(int id)
        {
            return await _domain.Delete(id);
        }

        private ProjectView ToProjectView(ProjectModel project)
        {
            return new ProjectView
            {
                Id = project.Id,
                Name = project.Name,
                Status = project.Status,
                DeadlineTime = project.DeadlineTime,
                PricePerHour = project.PricePerHour,
                //Tasks=(project.Tasks.Any() ?  null: project.Tasks.Select(ToTaskView).ToList())
                Tasks = project.Tasks?.Select(ToTaskView).ToList(),
            };
        }

        private TaskView ToTaskView(TaskModel taskModel)
        {
            return new TaskView
            {
                Name = taskModel.Name,
                Status = taskModel.Status,
                EstimatedTimeMinutes = taskModel.EstimatedTimeMinutes,
            };
        }

        private ProjectModel ToProject(ProjectView projectView)
        {
            return new ProjectModel
            {
                Id = projectView.Id,
                Name = projectView.Name,
                Status = projectView.Status,
                DeadlineTime = projectView.DeadlineTime,
                PricePerHour = projectView.PricePerHour
            };
        }

        private async Task ValidateAndThrowException(ProjectView projectView)
        {
            var validator = new ProjectViewValidator();
            await validator.ValidateAndThrowAsync(projectView);
        }
    }
}