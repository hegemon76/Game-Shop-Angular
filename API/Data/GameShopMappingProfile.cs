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
                .ForMember(m => m.Delivery, c => c.MapFrom(s => s.Delivery))
                .ForMember(m => m.Payment, c => c.MapFrom(s => s.Payment))
                .ForMember(m => m.Invoice, c => c.MapFrom(s => s.Payment.Invoice));

            CreateMap<Opinion, OpinionDto>()
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Description))
                .ForMember(m => m.UserName, c => c.MapFrom(s => s.UserName));

            CreateMap<CreateNewOpinionDto, Opinion>();
            //CreateMap<OrderDto, Order>()
            //    .ForMember(m => m.DeliveryId, c => c.MapFrom(s => s.Delivery.Id))
            //    .ForMember(m => m.PaymentId, c => c.MapFrom(s => s.Payment.Id))
            //    .ForMember(m => m.TotalPrice, c => c.MapFrom(s => s.TotalPrice));

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<Basket, BasketDto>();

            CreateMap<CreateNewProductDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(m => m.Genre, c => c.MapFrom(s => s.Genre.Name));
        
        
        }    
    }
}
