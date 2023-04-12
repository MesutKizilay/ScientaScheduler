using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Business.Services.Interface;
using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("GetActiveTaskList")]
        public async Task<IActionResult> GetActiveTaskList()
        {
            List<GGorev> gorevler = new();
            gorevler = await _taskService.GetActiveTaskList();
            return Ok(gorevler);
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(GGorev gGorev)
        {
            var result = await _taskService.UpdateTask(gGorev);
            return Ok(result);
        }

        [HttpPut("DeleteTask")]
        public async Task<IActionResult> DeleteTask(GGorev gGorev)
        {
            var result = await _taskService.DeleteTask(gGorev);
            return Ok(result);
        }
    }
}