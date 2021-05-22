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
        public ActionResult<CreateNewOpinionDto> AddOpinion ([FromBody] CreateNewOpinionDto dto, [FromRoute] int id)
        {
            _service.AddOpinion(dto, id);
            return Created($"api/videogames/search/product/id", null);
        }
        
        [HttpGet("myorders")]
        public ActionResult<OrderDto> MyOrders()
        {
            var myOrders= _service.MyOrders();
            return Ok(myOrders);
        }

    }
}
