using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Dispatch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string OrderNumber { get; set; }  // Číslo objednávky

        [Required]
        public required string Destination { get; set; }  // Cílová destinace

        public DateTime DispatchDate { get; set; } = DateTime.UtcNow;  // Datum odeslání

        // Možné cizí klíče na uživatele (např. dispečer)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
