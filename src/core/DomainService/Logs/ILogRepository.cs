using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Logs;

namespace TimeLogger.DomainService.Logs
{
    public interface ILogRepository : IRepositoryService
    {
        public Task<LogModel> Add(LogModel logModel);
        public Task<LogModel> Update(LogModel logModel);
        public Task<LogModel> FindById(int id);
        public Task<bool> Delete(int id);
        public Task<bool> HardDelete(int id);
        public Task<LogModel> GetLastRecord(int taskID);
    }
}