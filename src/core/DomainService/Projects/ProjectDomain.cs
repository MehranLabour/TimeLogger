using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Projects;

namespace TimeLogger.DomainService.Projects
{
    public class ProjectDomain : IProjectDomain
    {
        private readonly IProjectRepository _repository;

        public ProjectDomain(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectModel> Add(ProjectModel projectModel)
        {
            await ValidateProjectAndThrow(projectModel);
            var project = await _repository.Add(projectModel);
            return project;
        }

        public async Task<List<ProjectModel>> GetByName(string projectName, Paging paging)
        {
            return await _repository.GetByName(projectName, paging);
        }

        public async Task<ProjectModel> FindById(int id)
        {
            return await _repository.FindById(id);
        }
        

        public async Task<ProjectModel> Update(ProjectModel projectModel)
        {
           var result= await _repository.Update(projectModel);
           return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        private async Task ValidateProjectAndThrow(ProjectModel projectModel)
        {
            var validator = new ProjectValidator();
            await validator.ValidateAndThrowAsync(projectModel);
        }
    }
}