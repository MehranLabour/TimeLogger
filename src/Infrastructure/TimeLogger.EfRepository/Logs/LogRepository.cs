using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeLogger.AppService.Contract;
using TimeLogger.DomainService.Logs;
using TimeLogger.Model.Logs;

namespace TimeLogger.EfRepository.Logs
{
    public class LogRepository : ILogRepository
    {
        private readonly TimeLoggerContext _context;

        public LogRepository(TimeLoggerContext context)
        {
            _context = context;
        }

        

        public async Task<LogModel> Add(LogModel logModel)
        {
            _context.Add(logModel);
            await _context.SaveChangesAsync();
            return logModel;
        }

        public async Task<LogModel> Update(LogModel logModel)
        {
            var dbLog= await _context.Logs
                .Where(e => e.Id == logModel.Id)
                .FirstOrDefaultAsync();
            if (dbLog != null)
            {
                dbLog.Description = logModel.Description;
                _context.SaveChangesAsync();
            }

            return dbLog;
        }

        public Task<LogModel> FindById(int id)
        {
           return _context.Logs
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var log =await  _context.Logs.FindAsync(id);
            if (log!=null)
            {
                log.Status = Status.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> HardDelete(int id)
        {
            var log =await  _context.Logs.FindAsync(id);
            if (log!=null)
            {
                 _context.Remove(log);
                 await _context.SaveChangesAsync();
                 return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<LogModel> GetLastRecord(int taskID)
        {
            return await _context.Logs.Where(e => e.TaskId == taskID)
                .OrderByDescending(e => e.Id).FirstOrDefaultAsync();
        }
    }
}
