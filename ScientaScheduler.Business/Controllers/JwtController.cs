using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CreateToken());
        }
    }
}
