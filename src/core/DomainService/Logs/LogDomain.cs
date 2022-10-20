using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Exceptions;
using TimeLogger.Model.Logs;

namespace TimeLogger.DomainService.Logs
{
    public class LogDomain:ILogDomain
    {
        private readonly ILogRepository _repository;

        public LogDomain(ILogRepository repository)
        {
            _repository = repository;
        }

        public async Task<LogModel> Add(LogModel logModel)
        {
            await ValidateTaskAndThrow(logModel);
            var log = await _repository.Add(logModel);
            return log;
        }

        public async Task<LogModel> Update(LogModel logModel)
        {
            return await _repository.Update(logModel);
        }

        public async Task<LogModel> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public Task<bool> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<bool> HardDelete(int id)
        {
            return await _repository.HardDelete(id);
        }
        private async Task ValidateTaskAndThrow(LogModel logModel)
        {
            var validator = new LogValidator();
            var overlap= await CheckIsOverLap(logModel);
            await validator.ValidateAndThrowAsync(logModel);
        }

        private async Task<bool> CheckIsOverLap(LogModel newlogModel)
        {
           var lastLog= await _repository.GetLastRecord(newlogModel.TaskId);
           if (lastLog != null)
           {
               if (newlogModel.StartsAt <= lastLog.EndsAt)
               {
                   //return true;
                   throw new IsOverLapException(
                       "dates of log over Lapped");
               }
           }

           return false;
        }
    }
}
