using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string CourseCode { get; set; }

    [Required]
    public required DateTime DepartureDate { get; set; }

    [Required]
    public required string Network { get; set; }

    public int TransporterEnumId { get; set; } 

    public string? Seals { get; set; }

    public TimeSpan? DeparturePlannedTime { get; set; }

    // Relace: Každý kurz má jednu lokaci
    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
