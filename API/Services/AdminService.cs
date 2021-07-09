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
        Task UpdateUser(UserDto user, int userId);
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

        public async Task UpdateUser(UserDto user, int userId)
        {
            var findUser =await _context.Users
                .Include(x=>x.Address)
                .Include(x=>x.Role)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (findUser is null)
            {
                throw new NotFoundException("did not find user");
            }

            string newHashedPassword;

            if (findUser.PasswordHash != user.PasswordHash)
            {
                newHashedPassword = _passwordHasher.HashPassword(findUser, user.PasswordHash);
                findUser.PasswordHash = newHashedPassword;
            }

            findUser.Address.City = user.Address.City;
            findUser.Address.Country = user.Address.Country;
            findUser.Address.BuildingNumber = user.Address.BuildingNumber;
            findUser.Address.Street = user.Address.Street;
            findUser.Address.ZipCode = user.Address.ZipCode;
            findUser.RoleId = user.Role.Id;
            findUser.LastName = user.LastName;
            findUser.FirstName = user.FirstName;
            findUser.UserName = user.UserName;
            findUser.Email = user.Email;
            findUser.LastName = user.LastName;
            findUser.DateOfBirth = user.DateOfBirth;

            await _context.SaveChangesAsync();
        }



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
            const string defaultName = "/assets/Default.png";

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
