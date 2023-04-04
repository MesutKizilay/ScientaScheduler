using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Authentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly BuildToken _buildToken;
        public AuthController(BuildToken buildToken)
        {
            _buildToken = buildToken;
        }
        
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("", _buildToken.CreateToken());
        }        
        
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult SignIn()
        {
            return Ok();
        }
    }
}