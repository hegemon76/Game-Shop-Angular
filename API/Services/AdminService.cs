using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace API.Services
{
    public interface IAdminService
    {
        Task<Product> CreateNewProduct(CreateNewProductDto dto, IFormFile image);
        Task DeleteProduct(int productId);
        Task UpdateProduct(CreateNewProductDto dto, int productId);
        Task UpdateUser(User user, int userId);
        Task SetRoleForUser(SetRoleForUser dto);
        Task<List<UserDto>> GetAllUsers();
    }

    public class AdminService : IAdminService
    {
        private readonly GameShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminService> _logger;
        private readonly IUserContextService _userContextService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AdminService(GameShopDbContext context, IMapper mapper, ILogger<AdminService> logger, IUserContextService userContextService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _userContextService = userContextService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Product> CreateNewProduct(CreateNewProductDto dto, IFormFile image)
        {
            var newProduct = _mapper.Map<Product>(dto);
            newProduct.ImageURL = uploadImage(image);

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            // _logger.LogInformation($"Product {newProduct.Name} has been added by AdminId= {_userContextService.GetUserId}");
            
            return newProduct;
        }
        public async Task DeleteProduct(int productId)
        {
            var product = await getProduct(productId);

          //  _logger.LogInformation($"Product {product.Name} has been deleted by AdminId= {_userContextService.GetUserId}");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _context.Users
                .Include(x => x.Address)
                .Include(x => x.Role)
                .ToListAsync();
            var userDto = _mapper.Map<List<UserDto>>(users);

            return userDto;
        }

        public async Task SetRoleForUser(SetRoleForUser dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == dto.UserId);
            user.RoleId = dto.RoleId;

            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(CreateNewProductDto dto, int productId)
        {
            var product = await getProduct(productId);

            // _logger.LogInformation($"Product {product.Name} is going to be updated by AdminId= {_userContextService.GetUserId}");
            if (dto.Description != null)
            {
                product.Description = dto.Description;
            }
            if (dto.Name != null)
            {
                product.Name = dto.Name;
            }

            if (dto.Quantity.HasValue)
            {
                product.Quantity = dto.Quantity.Value;
            }
            if (dto.Price.HasValue)
            {
                product.Price = dto.Price.Value;
            }
            
            if(dto.Genre != null)
            {
                var genreId = _context.Genres.FirstOrDefault(x => x.Name == dto.Genre);
                product.GenreId = genreId.Id;
            }


            await _context.SaveChangesAsync();
            //  _logger.LogInformation($"Product {product.Name} has been updated by AdminId= {_userContextService.GetUserId}");
        }

        public async Task UpdateUser(User user, int userId)
        {
            var findUser = _context.Users.FirstOrDefault(x => x.Id == userId);
            
            var result = _passwordHasher.VerifyHashedPassword(user, findUser.PasswordHash, user.PasswordHash);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }
            user.Id = userId;
           // user.PasswordHash = password;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }


        //privates

        //private string checkForChangingPassword(string password, int userId) 
        //{
            

        //    if (findUser.PasswordHash != password)
        //    {
        //        var hashedPassword = _passwordHasher.HashPassword(findUser, password);
        //        password = hashedPassword;
        //    }
        //    return password;
        //}

        private async Task<Product> getProduct(int productId)
        {
            var product = await _context.Products
                           .FirstOrDefaultAsync(x => x.Id == productId);
            if (product is null)
                throw new NotFoundException("Nie znaleziono produktu");

            return product;
        }

        private string uploadImage(IFormFile image)
        {
            const string defaultName = "Default.png";

            if (image != null && image.Length > 0)
            {
                var imageName = image.FileName;
                var rootPath = Directory.GetCurrentDirectory();
                var fullPath = $"{rootPath}/Images/{imageName}";
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                return imageName;
            }

            return defaultName;
        }
    }
}
