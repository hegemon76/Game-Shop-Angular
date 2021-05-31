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
    [Route("api")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;
        }

        [HttpGet("basket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await _service.GetBasket();

            return Ok(basket);
        }

        [HttpGet("videogames/search/product/{id}/add")]
        public async Task<ActionResult<ProductDto>> AddToBasket([FromRoute] int id)
        {
            await _service.AddToBasket(id);

            return Created("api/Basket",null);
        }
        

        [HttpDelete("basket/product/{id}/delete")]
        public async Task<ActionResult<BasketDto>> DeleteProductFromBasket([FromRoute] int id)
        {
            await _service.DeleteFromBasket(id);

            return NoContent();
        }

        [HttpPost("basket/order/create")]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderDto dto)
        {
            await _service.CreateOrder(dto);

            return Created("api/myhistory/myorders", null);
        }

    }
}
