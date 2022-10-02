using System;
using TimeLogger.AppService.Contract.Wrappers;

namespace TimeLogger.AppService.Contract
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public PagedResponse(T data, int pageNumber, int pageSize):base (data,null,true)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
    }
}