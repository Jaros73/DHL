using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class Machining
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string MachineName { get; set; }

    [Required]
    public required string ProcessType { get; set; } 

    public TimeSpan? EstimatedTime { get; set; } // Může být volitelné

    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
