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
                .ForMember(m => m.Invoice, c => c.MapFrom(s => s.Payment.Invoice))
                
                ;

            //CreateMap<OrderDto, Order>()
            //    .ForMember(m => m.DeliveryId, c => c.MapFrom(s => s.Delivery.Id))
            //    .ForMember(m => m.PaymentId, c => c.MapFrom(s => s.Payment.Id))
            //    .ForMember(m => m.TotalPrice, c => c.MapFrom(s => s.TotalPrice));



            CreateMap<Basket, BasketDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        
        
        }    
    }
}
