using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Tasks;

namespace TimeLogger.DomainService.Tasks
{
    public interface ITaskRepository:IRepositoryService
    {
        public Task<TaskModel> Add(TaskModel taskModel);
        public Task<List<TaskModel>> GetByName(string projectName, Paging paging);

    }
}
