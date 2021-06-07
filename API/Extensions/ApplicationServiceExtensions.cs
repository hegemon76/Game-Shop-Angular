using API.Data;
using API.Entities;
using API.Middleware;
using API.Models;
using API.Models.Validator;
using API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<GameShopDbContext>();
            services.AddScoped<GameShopSeeder>();

            services.AddScoped<IVideoGamesService, VideoGamesService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IMyAccountService, MyAccountService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IOpinionService, OpinionService>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<RequestTimeMiddleware>();
            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            services.AddScoped<IValidator<SearchQuery>, ProductQueryValidator>();
          
            services.AddHttpContextAccessor();   
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            return services;
        }
    }
}
