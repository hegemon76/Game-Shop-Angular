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
    [Route("api/videogames/search")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGamesService _service;

        public VideoGamesController(IVideoGamesService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll([FromQuery] SearchQuery query)
        {
            var productsDtos =await _service.GetAll(query);

            return Ok(productsDtos);
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductDto>> Get([FromRoute] int id)
        {
            var product =await _service.GetById(id);

            return Ok(product);
        }
       
        [HttpPost("question")]
        public async Task<ActionResult<ProductDto>> AskQuestion([FromBody] AskQuestionDto dto)
        {
           await _service.AskQuestion(dto);

            return Ok("Question send");
        }
        
     

    }
}
