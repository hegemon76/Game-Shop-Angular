using API.Entities;
using API.Models;
using API.Services;
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
        private readonly GameShopDbContext _dbContext;
        private readonly IAccountService _service;

        public GameShopSeeder(GameShopDbContext dbContext, IAccountService service)
        {
            _dbContext = dbContext;
            _service = service;
        }

        public void SeedGenres()
        {
            try
            {
                if (!_dbContext.Genres.Any())
                {
                    var genresData = File.ReadAllText("./Data/genres.json");

                    var genres = JsonSerializer.Deserialize<List<Genre>>(genresData);

                    _dbContext.Genres.AddRange(genres);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SeedGames()
        {
            try
            {
                if (!_dbContext.Products.Any())
                {
                    var productsData = File.ReadAllText("./Data/games.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SeedOpinions()
        {
            try
            {
                if (!_dbContext.Opinions.Any())
                {
                    var opinionsData = File.ReadAllText("./Data/opinions.json");

                    var opinions = JsonSerializer.Deserialize<List<Opinion>>(opinionsData);

                    _dbContext.Opinions.AddRange(opinions);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void SeedUsers()
        {
            try
            {
                if (!_dbContext.Users.Any())
                {
                    var usersData = File.ReadAllText("./Data/users.json");

                    var users = JsonSerializer.Deserialize<List<RegisterUserDto>>(usersData);
                    foreach (var item in users)
                    {
                        _service.Register(item);
                    }                  
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SeedAsync()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                SeedGenres();
                SeedGames();
                SeedOpinions();
                SeedUsers();

                if (!_dbContext.UserQuestions.Any())
                {
                    var userQuestions = GetUserQuestions();
                    _dbContext.UserQuestions.AddRange(userQuestions);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Orders.Any())
                {
                    var orders = GetOrders();
                    _dbContext.Orders.AddRange(orders);
                    _dbContext.SaveChanges();
                }

            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
                    {
                        new Role()
                        {
                            Name="User"
                        },
                        new Role()
                        {
                            Name = "Admin",
                        }
                    };
            return roles;
        }
        private IEnumerable<UserQuestion> GetUserQuestions()
        {
            var questions = new List<UserQuestion>()
            {
                new UserQuestion()
                {
                    UserId=1,
                    Description="First Question"
                },
                new UserQuestion()
                {
                    UserId=2,
                    Description="Second Question"
                },
                new UserQuestion()
                {
                    UserId=1,
                    Description="Third Question"
                },
            };

            return questions;
        }

        private IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                    UserId=1,
                    Delivery=new InPerson(),
                    Payment=new Cash(),
                    DateOfOrder=DateTime.Now
                },
            };
            return orders;
        }
    }
}

