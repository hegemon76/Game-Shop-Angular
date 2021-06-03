using API.Data;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenres();
        Task AddGenre(string name);
    }

    public class GenreService : IGenreService
    {
        private GameShopDbContext _context;
        private IMapper _mapper;
        private IUserContextService _userContextService;

        public GenreService(GameShopDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<List<Genre>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            //var mapped = _mapper.Map<List<Genre>>(genres);
            return genres;
        }

        public Task AddGenre(string name)
        {
            throw new NotImplementedException();
        }
    }
}
