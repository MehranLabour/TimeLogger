using System.Collections.Generic;
using System.Threading.Tasks;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Projects;

namespace TimeLogger.DomainService.Projects
{
    public interface IProjectDomain:IDomainService
    {
        public Task<ProjectModel> Add(ProjectModel projectModel);
        public Task<List<ProjectModel>> GetByName(string projectName, Paging paging);
        public Task<ProjectModel> FindById(int id);
        public Task<ProjectModel> Update(ProjectModel projectModel);
        public Task<bool> Delete(int id);




    }
}