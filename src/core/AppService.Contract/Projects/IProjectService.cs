using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeLogger.AppService.Contract.Projects
{
    public interface IProjectService: IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectView"></param>
        /// <returns>id of added project</returns>
        public Task<ProjectView> Add(ProjectView projectView);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectView"></param>
        /// <returns>true if success, false if failed</returns>
        public Task<ProjectView> Update(ProjectView projectView);
        /// <summary>
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="paging"></param>

        /// <returns>list of tasks, actually its search by name in projects</returns>

        public Task<List<ProjectView>> GetByName(string projectName, Paging paging);
        /// <summary>
        /// </summary>
        /// <param name="id"></param>

        /// <returns>find or fail for finding project that id given</returns>
        public Task<ProjectView?> FindById(int id);
        public Task<bool> Delete(int id);

    }
}