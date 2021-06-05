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
                .ForMember(m => m.Payment, c => c.MapFrom(s => s.Payment));

            CreateMap<Opinion, OpinionDto>();

            CreateMap<CreateNewOpinionDto, Opinion>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<CreateNewProductDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(m => m.Genre, c => c.MapFrom(s => s.Genre.Name));

            CreateMap<User, UserDto>()
                .ForMember(m => m.Address, c => c.MapFrom(s => s.Address))
                .ForMember(m => m.Role, c => c.MapFrom(s => s.Role));

            CreateMap<UserDto, User>()
                .ForMember(m => m.Address, c => c.MapFrom(s => s.Address))
                .ForMember(m => m.Role, c => c.MapFrom(s => s.Role)); 

        }    
    }
}
