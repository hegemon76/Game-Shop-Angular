using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DeliveryName { get; set; }
        public int DeliveryPrice { get; set; }
        public string PaymentName { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int BasketPrice { get; set; }
        public int ItemCount { get; set; }
        public int TotalPrice { get; set; }
        public bool Invoice { get; set; }
        public List<Product> Products { get; set; }

    }
}
