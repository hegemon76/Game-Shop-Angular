using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class BasketDto
    {
        public int TotalPrice { get; set; }
        public int ItemCount { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
