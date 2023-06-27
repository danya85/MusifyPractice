using System.ComponentModel.DataAnnotations;

namespace Core.DomainLayer.Models
{
    public class Country
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}