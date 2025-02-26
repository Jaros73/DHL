using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string FullName { get; set; } = string.Empty; // Přidána výchozí hodnota

        [Required]
        [MaxLength(255)]
        public required string Email { get; set; } = string.Empty; // Přidána výchozí hodnota

        [Required]
        public required string PasswordHash { get; set; } = string.Empty; // Přidána výchozí hodnota

        [Required]
        public required string Role { get; set; } = "User"; // Výchozí role

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
