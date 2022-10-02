using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogger.AppService.Contract.Tasks
{
    public interface ITaskService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskView"></param>
        /// <returns>id of added task</returns>
        public Task<TaskView> Add(TaskView taskView);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskView"></param>
        /// <returns>true if operation succeeded and false if operation failed</returns>
        public Task<bool> Update(TaskView taskView);

        /// <summary>
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="paging"></param>

        /// <returns>list of tasks, actually its search by name in tasks</returns>

        public Task<List<TaskView>> GetByName(string taskName, Paging paging);
       
        /// <summary>
        /// </summary>
        /// <param name="id"></param>

        /// <returns>find or fail for finding task that id given</returns>
        public Task<TaskView> findById(int id);
    }
}
