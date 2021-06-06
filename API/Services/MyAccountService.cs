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
    public interface IMyAccountService
    {
        Task<List<OrderDto>> MyOrders();
        Task<UserDto> GetUser(int id);
    }

    public class MyAccountService : IMyAccountService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public MyAccountService(GameShopDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user =await _context.Users
                 .Include(x => x.Address)
                 .Include(x => x.Role)
                 .FirstOrDefaultAsync(x => x.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<List<OrderDto>> MyOrders()
        {
            var myOrders =await _context.Orders
                .Include(x => x.User)
                .Where(x => x.UserId == _userContextService.GetUserId)
                .Include(x => x.Payment)
                .Include(x => x.Delivery)
                .ToListAsync();
          
            var result = _mapper.Map<List<OrderDto>>(myOrders);
            return result;
        }

    }
}
