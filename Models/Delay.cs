using System.ComponentModel.DataAnnotations;
namespace DHL.Models;

public class Delay
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Reason { get; set; }

    public TimeSpan ExpectedDuration { get; set; }
}
