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
        public ActionResult<IEnumerable<ProductDto>> GetAll([FromQuery] SearchQuery query)
        {
            var productsDtos = _service.GetAll(query);

            return Ok(productsDtos);
        }

        [HttpGet("product/{id}")]
        public ActionResult<ProductDto> Get([FromRoute] int id)
        {
            var product = _service.GetById(id);

            return Ok(product);
        }
        [HttpPost("question")]
        public ActionResult<ProductDto> AskQuestion([FromBody] AskQuestionDto dto)
        {
            _service.AskQuestion(dto);

            return Ok("Question send");
        }
    }
}
