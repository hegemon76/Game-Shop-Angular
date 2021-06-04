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
    [ApiController]
    [Route("api/videogames/product/{id}")]
    public class OpinionController : ControllerBase
    {
        private readonly IOpinionService _service;

        public OpinionController(IOpinionService service)
        {
            _service = service;
        }

        [HttpGet("opinions")]
        public async Task<ActionResult<SelectListAsItems<OpinionDto>>> GetOpinions ([FromRoute]int id)
        {
            var opinions= await _service.GetOpinions(id);

            return Ok(opinions);
        }

        [Authorize]
        [HttpPost("addopinion")]
        public async Task<ActionResult<CreateNewOpinionDto>> AddOpinion([FromBody] CreateNewOpinionDto dto, [FromRoute] int id)
        {
            await _service.AddOpinion(dto, id);

            return Created($"api/videogames/product/{id}/opinions", null);
        }


    }
}
