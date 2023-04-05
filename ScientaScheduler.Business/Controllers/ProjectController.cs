using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Core.Entities.Concrete;
using ScientaSchedurler.Application.Infrastucture;
using System.Collections.Generic;

namespace ScientaScheduler.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProject project;

        public ProjectController(IProject project)
        {
            this.project = project;
        }

        [HttpGet]
        public IActionResult GetProjectList()
        {
            List<PYProje> projects = new();
            projects = project.GetProjectList();
            return Ok(projects);
        }

        [HttpPost]
        public IActionResult AddProject(PYProje pYProje)
        {
            project.AddProject(pYProje);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteProject(PYProje pYProje)
        {
            project.DeleteProject(pYProje);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProjectById(int id)
        {
            return Ok(project.GetProjectById(id));
        }

        [HttpPost]
        public IActionResult UpdateProject(PYProje pYProje)
        {
            project.UpdateProject(pYProje);
            return Ok();
        }
    }
}