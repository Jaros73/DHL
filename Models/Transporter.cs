using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Transporter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }  // Název dopravce

        [Required]
        public required string VehicleNumber { get; set; }  // SPZ vozidla

        public string? ContactInfo { get; set; }  // Kontaktní údaje

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;  // Datum registrace

        // Cizí klíč na uživatele (kdo přidal dopravce do systému)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
