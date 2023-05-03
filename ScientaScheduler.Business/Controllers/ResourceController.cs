using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Business.Services.Interface;
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
        IResourceService _resourceService;
        public ResourceController(IResource resource, IResourceService resourceService)
        {
            _resource = resource;
            _resourceService = resourceService;
        }

        //[HttpGet("GetResourceList")]
        //public IActionResult GetResourceList()
        //{
        //    return Ok(_resource.GetResourceList());
        //}        
        
        [HttpGet("GetResourceList")]
        public async Task<IActionResult> GetResourceList()
        {
            return Ok(await _resourceService.GetResourceList());
        }
    }
}