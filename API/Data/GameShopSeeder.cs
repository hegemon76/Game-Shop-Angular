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

                    foreach (var item in genres)
                    {
                        _dbContext.Genres.Add(item);
                    }
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

                    foreach (var item in products)
                    {
                        _dbContext.Products.Add(item);
                    }
                    _dbContext.Products.AddRange(products);
                    _dbContext.SaveChanges();
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

                SeedGames();
                SeedGenres();
                //if (!_dbContext.Products.Any())
                //{
                //    var products = GetProducts();
                //    _dbContext.Products.AddRange(products);
                //    _dbContext.SaveChanges();
                //}
                if (!_dbContext.Users.Any())
                {
                    GetUsers();
                }
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
        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product(){
                Name= "CS GO",
                Price=50,
                Quantity=30,
                Description="CSGO Description",

                },

                new Product(){
                Name= "Assassin's creed",
                Price=110,
                Quantity=12,
                Description="Assassin's creed Description",
                },
                new Product(){
                Name= "Metin2",
                Price=5,
                Quantity=1000,
                Description="Metin2  Description",
                },
            };

            return products;
        }

        private void GetUsers()
        {
            var newUser = new RegisterUserDto()
            {
                UserName = "test",
                Password = "test123",
                ConfirmPassword = "test123",
                Email = "test@gmail.com",
                FirstName = "xxx",
                LastName = "yyy",
                City = "zzz",
                Country = "ddd",
                ZipCode = "55-555",
                Street = "iii",
                DateOfBirth = new DateTime(1998, 06, 02),
            };
            _service.Register(newUser);

            var newUser2 = new RegisterUserDto()
            {
                UserName = "test2",
                Password = "test123",
                ConfirmPassword = "test123",
                Email = "test2@gmail.com",
                FirstName = "yyy",
                LastName = "ggg",
                City = "fff",
                Country = "kkk",
                ZipCode = "55-555",
                Street = "yyy",
                DateOfBirth = new DateTime(1978, 01, 07),
            };
            _service.Register(newUser2);
            var newUser3 = new RegisterUserDto()
            {
                UserName = "admin",
                Password = "admin123",
                ConfirmPassword = "admin123",
                Email = "admin@gmail.com",
                FirstName = "xxx",
                LastName = "zzz",
                City = "qqq",
                Country = "eee",
                ZipCode = "99-999",
                Street = "hhh",
                DateOfBirth = new DateTime(2000, 01, 11),
                RoleId = 2
            };
            _service.Register(newUser3);

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

