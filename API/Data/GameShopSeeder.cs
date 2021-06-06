using API.Entities;
using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace API.Data
{
    public class GameShopSeeder
    {

        public static async Task SeedGenres(GameShopDbContext _dbContext)
        {
            if (!await _dbContext.Genres.AnyAsync())
            {
                var genresData = File.ReadAllText("./Data/SeedersJson/genres.json");
                var genres = JsonSerializer.Deserialize<List<Genre>>(genresData);

                await _dbContext.Genres.AddRangeAsync(genres);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedGames(GameShopDbContext _dbContext)
        {
            if (!await _dbContext.Products.AnyAsync())
            {
                var productsData = File.ReadAllText("./Data/SeedersJson/games.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                await _dbContext.Products.AddRangeAsync(products);
                await _dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedOpinions(GameShopDbContext _dbContext)
        {
            if (!await _dbContext.Opinions.AnyAsync())
            {
                var opinionsData = File.ReadAllText("./Data/SeedersJson/opinions.json");
                var opinions = JsonSerializer.Deserialize<List<Opinion>>(opinionsData);

                await _dbContext.Opinions.AddRangeAsync(opinions);
                await _dbContext.SaveChangesAsync();
            }

        }
        private static async Task SeedUsers(GameShopDbContext _dbContext, IAccountService service)
        {
            if (!await _dbContext.Users.AnyAsync())
            {
                var _service = service;
                var usersData = File.ReadAllText("./Data/SeedersJson/users.json");
                var users = JsonSerializer.Deserialize<List<RegisterUserDto>>(usersData);
                
                foreach (var item in users)
                {
                    _service.Register(item);
                }
            }
        }
        private static async Task SeedRoles(GameShopDbContext _dbContext)
        {
            if (!await _dbContext.Roles.AnyAsync())
            {
                var rolesData = File.ReadAllText("./Data/SeedersJson/roles.json");
                var roles = JsonSerializer.Deserialize<List<Role>>(rolesData);
                
                await _dbContext.Roles.AddRangeAsync(roles);
                await _dbContext.SaveChangesAsync();
            }
        }

        public static async Task SeedAsync(GameShopDbContext _dbContext, IAccountService service)
        {
            if (_dbContext.Database.CanConnect())
            {
                if (await _dbContext.Users.AnyAsync())
                    return;
                
                await SeedRoles(_dbContext);
                await SeedGenres(_dbContext);
                await SeedGames(_dbContext);
                await SeedOpinions(_dbContext);
                await SeedUsers(_dbContext, service);
            }
        }
    }
}

