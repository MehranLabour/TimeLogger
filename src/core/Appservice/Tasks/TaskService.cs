using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.DomainService.Tasks;
using TimeLogger.Model.Logs;
using TimeLogger.Model.Tasks;

namespace TimeLogger.AppService.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskDomain _domain;

        public TaskService(ITaskDomain domain)
        {
            _domain = domain;
        }

        public async Task<TaskView> Add(TaskView taskView)
        {
            await ValidateAndThrowException(taskView);
            taskView.Status = Status.Accepted;
            var task = ToTask(taskView);
            var taskmodel = await _domain.Add(task);
            return ToTaskView(taskmodel);
        }

        public async Task<TaskView> Update(TaskView taskView)
        {
            var task = await _domain.Update(ToTask(taskView));
            return task == null ? null : ToTaskView(task);
        }

        public async Task<List<TaskView>> GetByName(string TaskName, Paging paging)
        {
            var tasks = await _domain.GetByName(TaskName, paging);
            return tasks.Select(ToTaskView).ToList();
        }

        public async Task<TaskView?> FindById(int id)
        {
            var task = await _domain.FindById(id);
            return task == null ? null : ToTaskView(task);
        }

        public async Task<bool> Delete(int id)
        {
            return await _domain.Delete(id);
        }

        private TaskView ToTaskView(TaskModel taskModel)
        {
            return new TaskView
            {
                Id = taskModel.Id,
                Name = taskModel.Name,
                Status = taskModel.Status,
                EstimatedTimeMinutes = taskModel.EstimatedTimeMinutes,
                ProjectId = taskModel.ProjectId,
                Logs = taskModel.Logs?.Select(ToLogView).ToList(),
            };
        }

        private LogView ToLogView(LogModel logModel)
        {
            return new LogView
            {
                Id = logModel.Id,
                Description = logModel.Description,
                StartsAt = logModel.StartsAt,
                EndsAt = logModel.EndsAt,
            };
        }

        private TaskModel ToTask(TaskView taskView)
        {
            return new TaskModel
            {
                Id = taskView.Id,
                Name = taskView.Name,
                Status = taskView.Status,
                EstimatedTimeMinutes = taskView.EstimatedTimeMinutes,
                ProjectId = taskView.ProjectId
            };
        }

        private async Task ValidateAndThrowException(TaskView taskView)
        {
            var validator = new TaskViewValidator();
            await validator.ValidateAndThrowAsync(taskView);
        }
    }
}