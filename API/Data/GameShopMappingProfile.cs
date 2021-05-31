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
                .ForMember(m => m.BasketPrice, c => c.MapFrom(s => s.User.Basket.TotalPrice))
                .ForMember(m => m.Delivery, c => c.MapFrom(s => s.Delivery))
                .ForMember(m => m.ItemCount, c => c.MapFrom(s => s.User.Basket.ItemCount))
                .ForMember(m => m.User, c => c.MapFrom(s => s.User))
                .ForMember(m => m.Payment, c => c.MapFrom(s => s.Payment))
                .ForMember(m => m.Products, c => c.MapFrom(s => s.User.Basket.Products));

            CreateMap<OrderDto, Order>()
                .ForMember(m => m.DateOfOrder, c => c.MapFrom(s => s.DateOfOrder))
                .ForMember(m => m.Delivery, c => c.MapFrom(s => s.Delivery))
                .ForMember(m => m.Payment, c => c.MapFrom(s => s.Payment))
                .ForMember(m => m.User, c => c.MapFrom(s => s.User));



            CreateMap<Basket, BasketDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        
        
        }    
    }
}
