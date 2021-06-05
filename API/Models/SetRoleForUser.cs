using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SetRoleForUser
    {
        public int UserId { get; set; }
        public int RoleId { get; set; } = 2;
    }
}
