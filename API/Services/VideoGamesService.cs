using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IVideoGamesService
    {
        Task<PagedResult<ProductDto>> GetAll(SearchQuery query);
        Task<ProductDto> GetById(int id);
        Task AskQuestion(AskQuestionDto dto);
    }

    public class VideoGamesService : IVideoGamesService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public VideoGamesService(GameShopDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }
        public async Task<ProductDto> GetById(int id)
        {
            var product =await _context
                .Products
                .Include(x => x.Genre)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (product is null)
                throw new NotFoundException("Product not found");

            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public async Task<PagedResult<ProductDto>> GetAll(SearchQuery query)
        {
            var baseQuery = _context
                .Products
                .Include(x => x.Genre)
                .Where(r => query.SearchPhrase == null || (r.Name.ToLower().Contains(query.SearchPhrase.ToLower())
                                                       || r.Description.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.GenreFiltr)) 
            {
                baseQuery=baseQuery.Where(r => r.Genre.Name.ToLower().Contains(query.GenreFiltr.ToLower()));
            }
                

                if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Product, object>>>
                {
                    { nameof(Product.Name), r => r.Name },
                    { nameof(Product.Price), r => r.Price },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var games =await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var totalItemsCount = baseQuery.Count();

            var ProductsDtos = _mapper.Map<List<ProductDto>>(games);

            var result = new PagedResult<ProductDto>(ProductsDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public async Task AskQuestion (AskQuestionDto dto)
        {
            var question = new UserQuestion()
            {
                UserId = (int)_userContextService.GetUserId,
                Description = dto.Description
            };

            _context.UserQuestions.Add(question);
            await _context.SaveChangesAsync();
        }



    }
}
