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
    [Authorize]
    [ApiController]
    [Route("api/myhistory")]
    public class MyHistoryController : ControllerBase
    {
        private readonly IMyHistoryService _service;

        public MyHistoryController(IMyHistoryService service)
        {
            _service = service;
        }

        
        [HttpGet("myorders")]
        public async Task<ActionResult<OrderDto>> MyOrders()
        {
            var myOrders= await _service.MyOrders();
            return Ok(myOrders);
        }

    }
}
