using API.Data;
using API.Entities;
using API.Middleware.Exceptions;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IAccountService
    {
        Task<string> GenerateJwt(LoginDto dto);
        void Register(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly GameShopDbContext _context;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(GameShopDbContext context, AuthenticationSettings authenticationSettings, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _authenticationSettings = authenticationSettings;
            _passwordHasher = passwordHasher;
        }

        public void Register(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                UserName = dto.UserName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId,
                Address =new Address()
                    {
                    City=dto.City,
                    ZipCode=dto.ZipCode,
                    Country=dto.Country,
                    Street=dto.Street,
                    BuildingNumber=dto.BuildingNumber
                },           
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var user =await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == dto.UserName);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }
            

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
                new Claim("Address", user.AddressId.ToString()),
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
