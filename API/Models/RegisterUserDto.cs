using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int BuildingNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
