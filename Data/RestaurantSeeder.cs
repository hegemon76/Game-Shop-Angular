using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
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
                    Name = "Manager",
                },
                new Role()
                {
                    Name = "Admin",
                }
            };
            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant(){
                Name= "KFC",
                Category="Fast Food",
                Description="KFC - american fastfood",
                HasDelivery=true,
                Dishes= new List<Dish>()
                {
                    new Dish()
                    {
                        Name="Nashville hot chicken",
                        Price=10.30M,
                        Description="Mniami"
                    },
                    new Dish()
                    {
                        Name="Chicken nuggets",
                        Price=5.30M,
                        Description="just perfect"
                    }
                },
                Address=new Address()
                {
                    City="Poznań",
                    Street="Parkowa",
                    ZipCode="64-316",
                }
                } ,


            new Restaurant()
            {
                Name = "Macdoland",
                Category = "Fast Food",
                Description = "McDonald- american fastfood",
                HasDelivery = true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name="McChicken",
                        Price=7.30M,
                        Description="delicious"
                    },
                    new Dish()
                    {
                        Name="Vanilla Shake",
                        Price=5.30M,
                        Description="Gorgeous"
                    }
                },
                Address = new Address()
                {
                    City = "kuślin",
                    Street = "Parkowa",
                    ZipCode = "64-316"
                }
            } 
            };
                 
            return restaurants;
        }
    }
}
