using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Name{ get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; } 
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
