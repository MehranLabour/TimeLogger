using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeLogger.AppService.Contract;
using TimeLogger.DomainService.Projects;
using TimeLogger.Model.Projects;

namespace TimeLogger.EfRepository.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TimeLoggerContext _context;

        public ProjectRepository(TimeLoggerContext context)
        {
            _context = context;
        }

        public async Task<ProjectModel> Add(ProjectModel projectModel)
        {
            _context.Add(projectModel);
            await _context.SaveChangesAsync();
            return projectModel;
        }

        public async Task<ProjectModel> Update(ProjectModel projectModel)
        {
            var dbProjectModel = await _context.Projects
                .Include(e => e.Tasks)
                .Where(p => p.Id == projectModel.Id)
                .FirstOrDefaultAsync();
            dbProjectModel.Name = projectModel.Name;
            await _context.SaveChangesAsync();
            return dbProjectModel;
        }

        public async Task<bool> Delete(int id)
        {
            var project =await  _context.Projects.FindAsync(id);
            if (project!=null)
            {
                project.Status = Status.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ProjectModel>> GetByName(string projectName, Paging paging)
        {
            return await _context.Projects
                .Include(e => e.Tasks)
                .Where(e => e.Name.Contains(projectName))
                .Where(e=>e.Status!=Status.Deleted)
                .Skip(paging.PageSize * (paging.PageNumber - 1))
                .Take(paging.PageSize).ToListAsync();
        }

        public async Task<ProjectModel> FindById(int id)
        {
            return await _context.Projects
                .Include(e => e.Tasks)
                .Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    }
}