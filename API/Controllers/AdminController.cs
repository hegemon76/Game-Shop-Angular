using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize(Roles="Admin")]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpPost("newproduct")]
        public async Task<ActionResult> CreateNewProduct ([FromBody] CreateNewProductDto dto, [FromForm] IFormFile image)
        {
            var newProductId =await _service.CreateNewProduct(dto, image);

            return Created($"api/videogames/search/product/{newProductId}", null);
        }

        [HttpDelete("delete/product/{productId}")]
        public async Task<ActionResult> DeleteProduct (int productId)
        {
            await _service.DeleteProduct(productId);
            
            return NoContent();
        }

        [HttpPut("product/{productId}/update")]
        public async Task<ActionResult> UpdateProduct([FromBody] CreateNewProductDto dto, int productId)
        {
            await _service.UpdateProduct(dto, productId);
            return Redirect($"api/videogames/search/product/{productId}");
        }
        
        [HttpPut("setrole/user")]
        public async Task<ActionResult> SetRoleForUser([FromQuery] SetRoleForUser dto)
        {
            await _service.SetRoleForUser(dto);
            return NoContent();
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users= await _service.GetAllUsers();
            return Ok(users);
        }

    }
}
