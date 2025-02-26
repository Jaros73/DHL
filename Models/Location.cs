using System.ComponentModel.DataAnnotations;

namespace DHL.Models;

public class Location
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Address { get; set; }

    // Relace: Jedna lokace má více zaměstnanců (Many-To-Many)
    public List<LocationAssignment> LocationAssignments { get; set; } = new List<LocationAssignment>();

    // Relace: Jedna lokace může mít více kurzů
    public List<Course> Courses { get; set; } = new List<Course>();
}
