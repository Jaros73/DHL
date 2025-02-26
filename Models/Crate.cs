using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Crate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string CrateNumber { get; set; }  // Číslo přepravky

        [Required]
        public required string Content { get; set; }  // Obsah přepravky

        public int Weight { get; set; }  // Hmotnost v kg

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Datum vytvoření

        // Cizí klíč na uživatele (kdo vytvořil záznam)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
