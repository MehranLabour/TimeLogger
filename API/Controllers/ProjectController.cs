using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Contract.Wrappers;
using TimeLogger.Model.Projects;

namespace API.Controllers
{
    //[ApiResultFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProjectView project)
        {
            var result = await _service.Add(project);
            return Ok(new Response<ProjectView>(result, "Record Created Successfully", true));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectView>>> GetByName(string name, int pagenumber, int pagesize)
        {
            var paging = new Paging
            {
                PageSize = pagesize,
                PageNumber = pagenumber
            };
            var result = await _service.GetByName(name, paging);
            return Ok(new PagedResponse<List<ProjectView>>(result, pagenumber, pagesize));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectView>> Get(int id)
        {
            var project = await _service.FindById(id);

            if (project == null)
                return NotFound(new Response<ProjectView>(project, "No Record Found", false));
            return Ok(new Response<ProjectView>(project, null, true));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjectView project)
        {
            var updatedproject = await _service.Update(project);
            return Ok(new Response<ProjectView>(updatedproject, "Record Updated Successfully", true));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result == false)
                return NotFound(new Response<ProjectView>(null, "No Such Record Found", false));
            return Ok(new Response<ProjectView>(null, "record Deleted Successfully", true));
        }
    }
}