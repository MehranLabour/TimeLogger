using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.AppService.Contract.Wrappers;

namespace API.Controllers
{
    //[ApiResultFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TaskView task)
        {
            var here = "lop";
            var result = await _service.Add(task);
            return Ok(new Response<TaskView>(result, "Record Created Successfully", true));
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TaskView>>> GetByName(string name, int pagenumber, int pagesize)
        {
            var paging = new Paging
            {
                PageSize = pagesize,
                PageNumber = pagenumber
            };
            var result = await _service.GetByName(name, paging);
            return Ok(new PagedResponse<List<TaskView>>(result, pagenumber, pagesize));
        }
        
    }
}