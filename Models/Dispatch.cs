using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class Dispatch
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string DispatcherName { get; set; }

    [Required]
    public required DateTime DispatchDate { get; set; }

    public string Status { get; set; } = "Pending"; // Výchozí hodnota

    // Relace: Každý dispečink může být přiřazen k lokaci
    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
