using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
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
        PagedResult<ProductDto> GetAll(SearchQuery query);
        ProductDto GetById(int id);
        void AskQuestion(AskQuestionDto dto);
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
        public ProductDto GetById(int id)
        {
            var product = _context
                .Products
                .FirstOrDefault(r => r.Id == id);

            if (product is null)
                throw new NotFoundException("Product not found");

            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public PagedResult<ProductDto> GetAll(SearchQuery query)
        {
            var baseQuery = _context
                .Products
                .Where(r => query.SearchPhrase == null || (r.Name.ToLower().Contains(query.SearchPhrase.ToLower())
                                                       || r.Description.ToLower()
                                                               .Contains(query.SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Product, object>>>
                {
                    { nameof(Product.Name), r => r.Name },
                    { nameof(Product.Price), r => r.Price },
                    { nameof(Product.Description), r => r.Description },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var restaurants = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var ProductsDtos = _mapper.Map<List<ProductDto>>(restaurants);

            var result = new PagedResult<ProductDto>(ProductsDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public void AskQuestion (AskQuestionDto dto)
        {
            var question = new UserQuestion()
            {
                UserId = (int)_userContextService.GetUserId,
                Description = dto.Description
                
            };

            _context.UserQuestions.Add(question);
            _context.SaveChanges();
        }



    }
}
