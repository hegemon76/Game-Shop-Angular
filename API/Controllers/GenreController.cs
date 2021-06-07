using API.Data;
using API.Entities;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll()
        {
            var result = await _service.GetGenres();
            
            return Ok(result);
        }

        //[Authorize(Roles ="Admin")]
        [HttpPost("add")]
        public async Task<ActionResult<GenreDto>> AddNewGenre([FromBody] GenreDto dto)
        {
            await _service.AddGenre(dto);

            return Created("api/genre", null);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("update")]
        public async Task<ActionResult<GenreDto>> UpdateGenre([FromBody] GenreDto genre, [FromQuery] string name)
        {
            await _service.UpdateGenre(genre, name);

            return Created("api/genre", genre);
        }
    }
}
