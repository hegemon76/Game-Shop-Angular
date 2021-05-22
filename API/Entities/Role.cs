using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; }
    }
}