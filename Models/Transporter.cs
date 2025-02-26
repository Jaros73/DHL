using System.ComponentModel.DataAnnotations;
namespace DHL.Models;

public class Transporter
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? ContactInfo { get; set; }
}
