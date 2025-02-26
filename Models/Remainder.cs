using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class Remainder
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string ItemName { get; set; }

    public int Quantity { get; set; } = 0; // Výchozí hodnota pro Quantity

    public string Status { get; set; } = "Čeká na doplnění"; // Výchozí hodnota pro Status

    // Relace: Každý zůstatek je přiřazen k lokaci
    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
