using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeLogger.AppService.Contract;
using TimeLogger.Model.Logs;
using TimeLogger.Model.Tasks;

namespace TimeLogger.DomainService.Logs
{
    public interface ILogDomain : IDomainService
    {
        public Task<LogModel> Add(LogModel task);
        public Task<LogModel> Update(LogModel logModel);
        public Task<LogModel> FindById(int id);
        public Task<bool> Delete(int id);
        public Task<bool> HardDelete(int id);
    }
}