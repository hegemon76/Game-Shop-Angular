using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/myaccount")]
    public class MyAccountController : ControllerBase
    {
        private readonly IMyAccountService _service;

        public MyAccountController(IMyAccountService service)
        {
            _service = service;
        }

        
        [HttpGet("myorders")]
        public async Task<ActionResult<OrderDto>> MyOrders()
        {
            var myOrders= await _service.MyOrders();
            return Ok(myOrders);
        }

        [HttpGet("user")]
        public async Task<ActionResult<UserDto>> GetUser([FromQuery] int id)
        {
            var user = await _service.GetUser(id);
            return Ok(user);
        }
    }
}
