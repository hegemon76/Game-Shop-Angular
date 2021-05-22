using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMyHistoryService
    {
        void AddOpinion(CreateNewOpinionDto opinion, int productId);
        List<OrderDto> MyOrders();
    }

    public class MyHistoryService : IMyHistoryService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public MyHistoryService(GameShopDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }
        public List<OrderDto> MyOrders()
        {
            var myOrders = _context.Orders
                .Include(x => x.User)
                
                .Where(x => x.UserId == _userContextService.GetUserId)
                .Include(x => x.Payment)
                .Include(x => x.Delivery)
                .ToList();
          
            var result = _mapper.Map<List<OrderDto>>(myOrders);

            return result;
        }
        public void AddOpinion(CreateNewOpinionDto opinion, int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product is null)
                throw new NotFoundException("Nie znaleziono produktu");

            var newOpinion = _mapper.Map<Opinion>(opinion);
            _context.Opinions.Add(newOpinion);
            _context.SaveChanges();

        }
    }
}
