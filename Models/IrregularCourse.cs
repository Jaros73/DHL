using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class IrregularCourse
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string CourseCode { get; set; }

    [Required]
    public required DateTime ScheduledDate { get; set; }

    public string? Reason { get; set; } // Důvod nepravidelného kurzu (může být null)

    // Relace: Každý nepravidelný kurz patří k lokaci
    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
