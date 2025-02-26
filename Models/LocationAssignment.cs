using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class LocationAssignment
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }

    public required Employee Employee { get; set; }

    [ForeignKey("Location")]
    public int LocationId { get; set; }

    public required Location Location { get; set; }

    public required string Role { get; set; } // Např. "Manager", "Worker"
}
