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

        [HttpPost("product/{id}/addopinion")]
        public async Task <ActionResult<CreateNewOpinionDto>> AddOpinion ([FromBody] CreateNewOpinionDto dto, [FromRoute] int id)
        {
            await _service.AddOpinion(dto, id);
            return Created($"api/videogames/search/product/id", null);
        }
        
        [HttpGet("myorders")]
        public async Task<ActionResult<OrderDto>> MyOrders()
        {
            var myOrders= await _service.MyOrders();
            return Ok(myOrders);
        }

    }
}
