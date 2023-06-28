using System.ComponentModel.DataAnnotations;

namespace Core.DomainLayer.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public Country Country { get; set; }

    public Role Role { get; set; }
}