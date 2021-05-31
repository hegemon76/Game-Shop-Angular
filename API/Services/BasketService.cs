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
    public interface IBasketService
    {
        Task AddToBasket(int id);
        Task DeleteFromBasket(int id);
        Task<BasketDto> GetBasket();
        Task<OrderDto> CreateOrder(OrderDto dto);
    }

    public class BasketService : IBasketService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public BasketService(GameShopDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<BasketDto> GetBasket()
        {
            var basket =await ReturnBasket();

            var basketDto = _mapper.Map<BasketDto>(basket);

            return basketDto;
        }

        public async Task AddToBasket(int id)
        {
            var basket = new Basket() { 
                ProductId = id,
                UserId= (int)_userContextService.GetUserId,
            };

            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFromBasket(int id)
        {
            var basketRecordToDelete =await _context.Baskets.FirstOrDefaultAsync(x => x.ProductId == id && x.UserId == _userContextService.GetUserId);
            if (basketRecordToDelete is null)
                throw new NotFoundException("Nie znaleziono rekordu");
            
            _context.Baskets.Remove(basketRecordToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDto> CreateOrder(OrderDto dto)
        {
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }
     
        //privates
        private async Task<Basket> ReturnBasket()
        {
            var basketsRecords = await _context.Baskets
                .Where(x => x.UserId == _userContextService.GetUserId)
                .ToListAsync();

            if (basketsRecords.Count<1)
                throw new NotFoundException("Nie masz jeszcze nic w koszyku");

            var basket = new Basket() { Products = new List<Product>() };

            foreach (var record in basketsRecords)
            {
                if (record.ProductId != null)
                {
                    var product = await ReturnProduct((int)record.ProductId);
                    basket.Products.Add(product);
                    basket.ItemCount++;
                    basket.TotalPrice += product.Price;
                }            
            }
            return basket;
        }
        private async Task<Product> ReturnProduct(int id)
        {
            var product =await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
                throw new NotFoundException("Nie znaleziono produktu");

            return product;
        }

        
    }
}
