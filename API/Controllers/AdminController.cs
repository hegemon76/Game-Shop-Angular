using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize(Roles="Admin")]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _service;

        public AdminController(IMapper mapper, IAdminService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpPost("newproduct")]
        public async Task<ActionResult> CreateNewProduct ([FromBody] ProductDto dto)
        {
            var newProductId =await _service.CreateNewProduct(dto);

            return Created("api/videogames/search/product/{newProductId}", null);
        }

        [HttpDelete("delete/product/{productId}")]
        public async Task<ActionResult> DeleteProduct (int productId)
        {
            await _service.DeleteProduct(productId);
            
            return NoContent();
        }

        [HttpPut("product/{productId}/update")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto dto, int productId)
        {
            await _service.UpdateProduct(dto, productId);
            return Redirect("api/videogames/search/product/{productId}");
        }
    }
}
