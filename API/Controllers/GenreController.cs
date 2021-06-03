using API.Data;
using API.Entities;
using API.Services;
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
        private readonly GameShopDbContext _context;

        public GenreController(GameShopDbContext context )
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
