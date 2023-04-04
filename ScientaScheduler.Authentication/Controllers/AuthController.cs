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
        private readonly BuildToken buildToken;

        public AuthController(BuildToken buildToken)
        {
            this.buildToken = buildToken;
        }

        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Ok(buildToken.CreateToken());
        }

        [HttpGet("[action]")]
        public IActionResult ValidateToken([FromQuery] string token)
        {
            if (buildToken.ValidateToken(token))
            {
                return Ok("Token is valid");
            }
            else
            {
                return Unauthorized("Token is not valid");
            }
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult SignIn()
        {
            return Ok();
        }
    }
}