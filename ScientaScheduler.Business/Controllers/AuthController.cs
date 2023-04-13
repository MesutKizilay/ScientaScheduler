using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Business.Authentication;
using ScientaScheduler.Business.DTOs;
using ScientaScheduler.Business.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]/*[Authorize]*/
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAuthorization _authorization;        

        public AuthController(IAuthService authService,IAuthorization authorization)
        {
            _authService = authService;
            _authorization = authorization;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result= await _authService.Login(userForLoginDto);
            // TODO : Scienta üzerinden kullanıcı adı ve şifre doğrulaması yapıldıktan sonra kullanıcıya ait bilgiler ve yetkiler eklenerek token oluşturulacak
            return Ok(_authorization.CreateToken(result));
        }

        [HttpGet("[action]")]
        public IActionResult ValidateToken([FromQuery] string token)
        {
            if (_authorization.ValidateToken(token))
            {
                return Ok("Token is valid");
            }
            else
            {
                return Unauthorized("Token is not valid");
            }
        }
    }
}