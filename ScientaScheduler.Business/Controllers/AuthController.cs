﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController][Authorize]
    public class AuthController : ControllerBase
    {
        
        [HttpGet("[action]")]
        public IActionResult SignIn()
        {
            return Ok("Başarıyla giriş yapıldı");
        } 

        [HttpGet("[action]")]
        public IActionResult SignUp()
        {
            return Ok("Başarıyla kayıt yapıldı");
        }
    }
}