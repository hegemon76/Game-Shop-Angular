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
    //[Authorize(Roles="Admin")]
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
        public ActionResult CreateNewProduct ([FromBody] ProductDto dto)
        {
            var newProductId = _service.CreateNewProduct(dto);

            return Created("api/videogames/search/product/{newProductId}", null);
        }

        [HttpDelete("delete/product/{productId}")]
        public ActionResult DeleteProduct (int productId)
        {
            _service.DeleteProduct(productId);
            
            return NoContent();
        }

        [HttpPut("product/{productId}/update")]
        public ActionResult UpdateProduct([FromBody] ProductDto dto, int productId)
        {
            _service.UpdateProduct(dto, productId);
            return Redirect("api/videogames/search/product/{productId}");
        }
    }
}
