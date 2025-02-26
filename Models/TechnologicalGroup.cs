using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class TechnologicalGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string GroupName { get; set; }  // Název technologické skupiny

        public string? Description { get; set; }  // Volitelný popis

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Datum vytvoření

        // Cizí klíč na uživatele (např. vedoucí technologické skupiny)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
