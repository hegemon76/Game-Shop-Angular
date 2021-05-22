using AutoMapper;
using API.Entities;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class GameShopMappingProfile: Profile
    {
        public GameShopMappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(m => m.BasketPrice, c => c.MapFrom(s => s.User.Basket.Price))
                .ForMember(m => m.DeliveryName, c => c.MapFrom(s => s.Delivery.Name))
                .ForMember(m => m.DeliveryPrice, c => c.MapFrom(s => s.Delivery.Price))
                .ForMember(m => m.ItemCount, c => c.MapFrom(s => s.User.Basket.ItemCount))
                .ForMember(m => m.UserFirstName, c => c.MapFrom(s => s.User.FirstName))
                .ForMember(m => m.UserLastName, c => c.MapFrom(s => s.User.LastName))
                .ForMember(m => m.PaymentName, c => c.MapFrom(s => s.Payment.Name))
                .ForMember(m => m.Products, c => c.MapFrom(s => s.User.Basket.Products));

            //CreateMap<Dish, DishDto>();

            //CreateMap<CreateRestaurantDto, Restaurant>()
            //    .ForMember(r => r.Address, c => c.MapFrom(dto => new Address()
            //            { City = dto.City, ZipCode = dto.ZipCode, Street = dto.Street }));

            //CreateMap<CreateDishDto, Dish>();
            
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        
        
        }    
    }
}
