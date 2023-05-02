using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaSchedurler.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        IResource _resource;

        public ResourceController(IResource resource)
        {
            _resource = resource;
        }

        [HttpGet("GetResourceList")]
        public IActionResult GetResourceList()
        {
            return Ok(_resource.GetResourceList());
        }
    }
}