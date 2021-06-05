using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [StringLength(8)]
        public string ZipCode { get; set; }
        [StringLength(40)]
        public string Country { get; set; }
        [StringLength(40)]
        public string Street { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        public int BuildingNumber { get; set; }
    }
}