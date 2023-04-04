using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScientaScheduler.Authentication.Authentication;

namespace ScientaScheduler.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorization authorization;

        public AuthController(IAuthorization authorization)
        {
            this.authorization = authorization;
        }

        [HttpGet("[action]")]
        public IActionResult Login()
        {
            // TODO : Scienta üzerinden kullanıcı adı ve şifre doğrulaması yapıldıktan sonra kullanıcıya ait bilgiler ve yetkiler eklenerek token oluşturulacak
            return Ok(authorization.CreateToken());
        }

        [HttpGet("[action]")]
        public IActionResult ValidateToken([FromQuery] string token)
        {
            if (authorization.ValidateToken(token))
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