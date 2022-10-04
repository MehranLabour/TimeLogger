using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Tasks;

namespace TimeLogger.DomainService.Tasks
{
    public class TaskDomain:ITaskDomain
    {
        private readonly ITaskRepository _repository;

        public TaskDomain(ITaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<TaskModel> Add(TaskModel task)
        {
            await ValidateTaskAndThrow(task);
            var taskModel = await _repository.Add(task);
            return taskModel;
        }

        public async Task<List<TaskModel>> GetByName(string TaskName, Paging paging)
        {
           return await _repository.GetByName(TaskName,paging);
        }

        public async Task<TaskModel> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<TaskModel> Update(TaskModel taskModel)
        {
            return await _repository.Update(taskModel);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }


        private async Task ValidateTaskAndThrow(TaskModel task)
        {
            var validator = new TaskValidator();
            await validator.ValidateAndThrowAsync(task);
        }
    }
}
