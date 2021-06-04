using API.Data;
using API.Entities;
using API.Models;
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
        Task<IEnumerable<GenreDto>> GetGenres();
        Task AddGenre(GenreDto dto);
    }

    public class GenreService : IGenreService
    {
        private GameShopDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(GameShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            var genresDto = _mapper.Map<List<GenreDto>>(genres);
            return genresDto;
        }

        public async Task AddGenre(GenreDto dto)
        {
            var genres = _mapper.Map<Genre>(dto);
            await _context.Genres.AddAsync(genres);
            await _context.SaveChangesAsync();
        }
    }
}
