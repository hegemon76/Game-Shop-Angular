using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } 
        public int ItemCount { get; set; } = 0;
        public int UserId { get; set; }
        
        public int? ProductId { get; set; }
        public virtual List<Product> Products { get; set; } 


    }
}