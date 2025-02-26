using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class RegionalReport
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required DateTime ReportDate { get; set; }

    [Required]
    public required string Region { get; set; }

    public string? Summary { get; set; } // Shrnutí může být volitelné

    // Relace: Report patří určité lokaci
    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
