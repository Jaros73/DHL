using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class RegionalReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string RegionName { get; set; }  // Název regionu

        [Required]
        public required string ReportContent { get; set; }  // Obsah hlášení

        public DateTime ReportDate { get; set; } = DateTime.UtcNow;  // Datum hlášení

        // Cizí klíč na uživatele (osoba, která vytvořila hlášení)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
