﻿using jwt_deneme.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace jwt_deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public  IActionResult Login()
        {
            return Created("", new BuildToken().CreatToken());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Page1()
        {

            return Ok("Sayfa 1 İçin Girişiniz Başarılı");

        }
    }
}
