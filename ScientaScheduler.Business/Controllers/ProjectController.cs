using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.Interfaces;
using System.Collections.Generic;

namespace ScientaScheduler.Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject project;

        public ProjectController(IProject project)
        {
            this.project = project;
        }

        [HttpGet]
        [Route("GetProjectList")]
        public IActionResult GetProjectList()
        {
            List<PYProje> projects = new();
            projects = project.GetProjectList();
            return Ok(projects);
        }

        [HttpPost]
        [Route("AddProject")]
        public IActionResult AddProject(PYProje pYProje)
        {
            project.AddProject(pYProje);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteProject")]
        public IActionResult DeleteProject(PYProje pYProje)
        {
            project.DeleteProject(pYProje);
            return Ok();
        }

        [HttpGet]
        [Route("GetProjectById")]
        public IActionResult GetProjectById(int id)
        {
            return Ok(project.GetProjectById(id));
        }

        [HttpPut]
        [Route("UpdateProject")]
        public IActionResult UpdateProject(PYProje pYProje)
        {
            project.UpdateProject(pYProje);
            return Ok();
        }
    }
}