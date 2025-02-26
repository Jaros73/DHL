using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Remainder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string ItemName { get; set; }  // Název položky

        [Required]
        public int Quantity { get; set; }  // Množství skladem

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;  // Datum poslední aktualizace

        // Cizí klíč na uživatele (kdo aktualizoval stav skladu)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
