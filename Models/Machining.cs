using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Machining
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string MachineName { get; set; }  // Název stroje

        [Required]
        public required string Operation { get; set; }  // Název operace

        public DateTime StartTime { get; set; } = DateTime.UtcNow;  // Čas zahájení operace

        public DateTime? EndTime { get; set; }  // Čas ukončení (může být null)

        public bool IsCompleted { get; set; } = false;  // Status dokončení

        // Cizí klíč na uživatele (operátor stroje)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
