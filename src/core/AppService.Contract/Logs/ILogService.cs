using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogger.AppService.Contract.Logs
{
    public interface ILogService:IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logView"></param>
        /// <returns>id of added log</returns>
        public Task<LogView> Add(LogView logView);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logView"></param>
        /// <returns>true if operation succeeded fail if failed</returns>
        public Task<LogView> Update(LogView logView);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>find log by id</returns>
        public Task<LogView> FindById(int id);
        /// <summary>
        /// </summary>
        /// <param name="id"></param>

        /// <returns>find or fail for finding item And Delete it,
        /// if succeeded return true if failed return false </returns>
        public Task<bool> Delete(int id);
        /// <summary>
        /// </summary>
        /// <param name="id"></param>

        /// <returns>find or fail for finding item And Delete it,
        /// if succeeded return true if failed return false </returns>
        public Task<bool> HardDelete(int id);

    }
}
