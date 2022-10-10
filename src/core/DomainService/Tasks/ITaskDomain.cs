using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Tasks;

namespace TimeLogger.DomainService.Tasks
{
    public interface ITaskDomain:IDomainService
    {
        public Task<TaskModel> Add(TaskModel task);
        public Task<List<TaskModel>> GetByName(string projectName, Paging paging);
        public Task<TaskModel> FindById(int id);
        public Task<TaskModel> Update(TaskModel taskModel);
        public Task<bool> Delete(int id);


    }
}
