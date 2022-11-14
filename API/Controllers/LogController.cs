﻿using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.Exceptions;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.AppService.Contract.Wrappers;

namespace API.Controllers
{
    //[ApiResultFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly ILogService _service;
        private readonly IJwtService _jwtService;

        public LogController(ILogService service,IJwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LogView log)
        {
            var result = await _service.Add(log);
            return Ok(new Response<LogView>(result, "Record Created Successfully", true));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LogView>> Get(int id)
        {
            var log = await _service.FindById(id);

            if (log == null)
                return NotFound(new Response<LogView>(log, "No Record Found", false));
            return Ok(new Response<LogView>(log, null, true));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LogView log)
        {
            var updatedLog = await _service.Update(log);
            if (updatedLog == null)
                return NotFound(new Response<LogView>(updatedLog, "No Record Found", false));
            return Ok(new Response<LogView>(updatedLog, "Record Updated Successfully", true));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result == false)
                return NotFound(new Response<LogView>(null, "No Such Record Found", false));
            return Ok(new Response<LogView>(null, "Record Deleted Successfully", true));
        }

        [HttpDelete("hard-delete")]
        public async Task<ActionResult> HardDelete(int id)
        {
            var result = await _service.HardDelete(id);
            if (result == false)
                return NotFound(new Response<LogView>(null, "No Such Record Found", false));
            return Ok(new Response<LogView>(null, "Record HardDeleted Successfully", true));
        }
    }
}