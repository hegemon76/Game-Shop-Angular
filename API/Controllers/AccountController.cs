using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

       [HttpPost("register")]
       public ActionResult<RegisterUserDto> CreateNewUser ([FromBody] RegisterUserDto dto)
        {
             _service.Register(dto);
            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login ([FromBody] LoginDto dto)
        {
            var token =await _service.GenerateJwt(dto);
            return Ok(token);
        }

    }
}
