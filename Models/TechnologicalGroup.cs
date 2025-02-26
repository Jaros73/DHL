using System.ComponentModel.DataAnnotations;

namespace DHL.Models;

public class TechnologicalGroup
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
}
