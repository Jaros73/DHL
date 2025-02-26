using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models
{
    public class Delay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Reason { get; set; }  // Důvod zpoždění

        public int DurationMinutes { get; set; }  // Doba zpoždění v minutách

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;  // Datum nahlášení

        // Cizí klíč na dispečera, který nahlásil zpoždění
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }  // Navigační vlastnost
    }
}
