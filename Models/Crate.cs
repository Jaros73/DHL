using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class Crate
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string CrateCode { get; set; }

    public int Capacity { get; set; }

    // Relace: Každá bedna je přiřazena k lokaci
    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }
}
