using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeLogger.AppService.Contract;
using TimeLogger.DomainService.Tasks;
using TimeLogger.Model.Tasks;

namespace TimeLogger.EfRepository.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TimeLoggerContext _context;

        public TaskRepository(TimeLoggerContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> Add(TaskModel taskModel)
        {
            _context.Add<TaskModel>(taskModel);
            await _context.SaveChangesAsync();
            return taskModel;
        }
        
        public async Task<List<TaskModel>> GetByName(string taskName, Paging paging)
        {
            return await _context.Tasks
                .Include(e => e.Logs)
                .Where(e => e.Name.Contains(taskName))
                .Where(e => e.Status != Status.Deleted)
                .Skip(paging.PageSize * (paging.PageNumber - 1))
                .Take(paging.PageSize).ToListAsync();
        }

        public async Task<TaskModel> FindById(int id)
        {
            return await _context.Tasks
                .Include(e => e.Logs)
                .Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TaskModel> Update(TaskModel taskModel)
        {
            var dbTaskModel = await _context.Tasks
                .Include(e => e.Logs)
                .Where(p => p.Id == taskModel.Id)
                .FirstOrDefaultAsync();
            if (dbTaskModel!=null)
            {
                dbTaskModel.Name = taskModel.Name;
                await _context.SaveChangesAsync(); 
            }
            return dbTaskModel;
        }

        public async Task<bool> Delete(int id)
        {
            var task=await _context.Tasks.FindAsync(id);
            if (task!=null)
            {
                task.Status = Status.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}