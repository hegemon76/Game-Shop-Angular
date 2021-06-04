using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IAdminService
    {
        Task<int> CreateNewProduct(CreateNewProductDto dto);
        Task DeleteProduct(int productId);
        Task UpdateProduct(CreateNewProductDto dto, int productId);
    }

    public class AdminService : IAdminService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminService> _logger;
        private readonly IUserContextService _userContextService;

        public AdminService(GameShopDbContext context, IMapper mapper, ILogger<AdminService> logger, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _userContextService = userContextService;
        }

        public async Task<int> CreateNewProduct(CreateNewProductDto dto)
        {
            var newProduct = _mapper.Map<Product>(dto);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Product {newProduct.Name} has been added by AdminId= {_userContextService.GetUserId}");

            return newProduct.Id;
        }
        public async Task DeleteProduct(int productId)
        {
            var product =await GetProduct(productId);

            _logger.LogInformation($"Product {product.Name} has been deleted by AdminId= {_userContextService.GetUserId}");
           
           _context.Products.Remove(product);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(CreateNewProductDto dto, int productId)
        {
            var product =await GetProduct(productId);
            
            _logger.LogInformation($"Product {product.Name} is going to be updated by AdminId= {_userContextService.GetUserId}");
           
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Quantity = dto.Quantity;
            product.Price = dto.Quantity;
            product.GenreId = dto.GenreId;
            
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product {product.Name} has been updated by AdminId= {_userContextService.GetUserId}");
        }

        //privates
        private async Task<Product> GetProduct(int productId)
        {
            var product = await _context.Products
                           .FirstOrDefaultAsync(x => x.Id == productId);
            if (product is null)
                throw new NotFoundException("Nie znaleziono produktu");
            
            return product;
        }
    }
}
