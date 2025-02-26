using System.ComponentModel.DataAnnotations;

namespace DHL.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public required string Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

