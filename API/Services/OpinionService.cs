using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IOpinionService
    {
        Task<SelectListAsItems<OpinionDto>> GetOpinions(int id);
        Task AddOpinion(CreateNewOpinionDto opinion, int productId);
    }

    public class OpinionService : IOpinionService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public OpinionService(GameShopDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<SelectListAsItems<OpinionDto>> GetOpinions(int id)
        {
            var opinions = await _context
                .Opinions
                .Where(x => x.ProductId == id)
                .ToListAsync();

            if (opinions is null || opinions.Count==0)
                throw new NotFoundException("Nie dodano jeszcze żadnych opini do tego artykułu");
            

            var opinionsDto = _mapper.Map<List<OpinionDto>>(opinions);
            var opinionsAsList = new SelectListAsItems<OpinionDto>(opinionsDto);
            
            return opinionsAsList;
        }
        public async Task AddOpinion(CreateNewOpinionDto opinion, int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product is null)
                throw new NotFoundException("Nie znaleziono produktu");

            var newOpinion = _mapper.Map<Opinion>(opinion);
            newOpinion.ProductId = productId;
            newOpinion.UserName = _userContextService.GetUserName;

             _context.Opinions.Add(newOpinion);
            await _context.SaveChangesAsync();

        }
    }
}
