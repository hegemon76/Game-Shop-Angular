using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderDto
    {
        public User User { get; set; }
        public Payment Payment { get; set; }
        public Delivery Delivery { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int BasketPrice { get; set; }
        public int ItemCount { get; set; }
        public int TotalPrice { get; set; }
        public bool Invoice { get; set; }

    }
}
