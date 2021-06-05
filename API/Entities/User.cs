using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [StringLength(30)]
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
       
        [StringLength(40)]
        public string FirstName { get; set; }
        
        [StringLength(40)]
        public string LastName { get; set; }
        
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public List<Order> Orders { get; set; }
        public List<UserQuestion> UserQuestions { get; set; }
    }
}
