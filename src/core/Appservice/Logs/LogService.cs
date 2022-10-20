using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.DomainService.Logs;
using TimeLogger.Model.Logs;

namespace TimeLogger.AppService.Logs
{
    public class LogService:ILogService
    {
        private readonly ILogDomain _domain;

        public LogService(ILogDomain domain)
        {
            _domain = domain;
        }

        public async Task<LogView> Add(LogView logView)
        {
            await ValidateAndThrowException(logView);
            var log = ToLog(logView);
            var logModel = await _domain.Add(log);
            return ToLogView(logModel);
        }
        
        public async Task<LogView> Update(LogView logView)
        {
            var log= await _domain.Update(ToLog(logView));
            return log !=null ? ToLogView(log) : null;
        }
        public async Task<LogView?> FindById(int id)
        {
            var log = await _domain.FindById(id);
            return log == null ? null : ToLogView(log);
        }

        public async Task<bool> Delete(int id)
        {
            return await _domain.Delete(id);
        }
        public async Task<bool> HardDelete(int id)
        {
            return await _domain.HardDelete(id);
        }

        private LogModel ToLog(LogView logView)
        {
            return new LogModel
            {
                Id = logView.Id,
                Description = logView.Description,
                Status = logView.Status,
                EstimatedTimeMinutes=logView.EstimatedTimeMinutes,
                StartsAt = logView.StartsAt,
                EndsAt = logView.EndsAt,
                TaskId = logView.TaskId
            };
        }
        private LogView ToLogView(LogModel logModel)
        {
            return new LogView
            {
                Id = logModel.Id,
                Description = logModel.Description,
                Status = logModel.Status,
                EstimatedTimeMinutes=logModel.EstimatedTimeMinutes,
                StartsAt = logModel.StartsAt,
                EndsAt = logModel.EndsAt,
                TaskId  = logModel.TaskId
            };
        }

        private async Task ValidateAndThrowException(LogView logView)
        {
            var validator = new LogViewValidator();
            await validator.ValidateAndThrowAsync(logView);
        }

        
    }
}
