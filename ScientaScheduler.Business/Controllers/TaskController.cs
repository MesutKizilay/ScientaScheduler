using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _task;

        public TaskController(ITask _task)
        {
            this._task = _task;
        }

        [HttpGet("GetTaskList")]
        public IActionResult Get_taskList()
        {
            return Ok(_task.GetTaskList());
        }

        [HttpPost("AddTask")]
        public IActionResult Add_task(GGorev GGorev)
        {
            _task.AddTask(GGorev);
            return Ok();
        }

        [HttpDelete("DeleteTask")]
        public IActionResult Delete_task(GGorev GGorev)
        {
            _task.DeleteTask(GGorev);
            return Ok();
        }

        [HttpGet("GetTaskById")]
        public IActionResult Get_taskById(int id)
        {
            return Ok(_task.GetTaskById(id));
        }

        [HttpPut("UpdateTask")]
        public IActionResult Update_task(GGorev GGorev)
        {
            _task.UpdateTask(GGorev);
            return Ok();
        }
    }
}