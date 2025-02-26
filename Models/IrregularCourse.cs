using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class IrregularCourse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string CourseName { get; set; }  // Název nepravidelného kurzu

        public string? Description { get; set; }  // Volitelný popis

        public DateTime StartDate { get; set; } = DateTime.UtcNow;  // Datum zahájení

        public DateTime? EndDate { get; set; }  // Datum ukončení (může být null)

        // Cizí klíč na uživatele (např. vedoucí kurzu)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
