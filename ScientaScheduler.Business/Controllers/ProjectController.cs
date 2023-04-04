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
    }
}
