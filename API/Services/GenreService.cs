using API.Data;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task AddGenre(string name);
    }

    public class GenreService : IGenreService
    {
        private GameShopDbContext _context;

        public GenreService(GameShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            //var genres = await _context.Genres.ToListAsync();
            //var mapped = _mapper.Map<List<Genre>>(genres);
            return await _context.Genres.ToListAsync();
        }

        public Task AddGenre(string name)
        {
            throw new NotImplementedException();
        }
    }
}
