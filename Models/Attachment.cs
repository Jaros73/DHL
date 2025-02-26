using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FileName { get; set; }  // Název souboru

        [Required]
        public required string FilePath { get; set; }  // Cesta k souboru na serveru

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;  // Datum nahrání

        // Cizí klíč na uživatele (kdo soubor nahrál)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
