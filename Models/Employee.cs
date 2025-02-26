using System.ComponentModel.DataAnnotations;

namespace DHL.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    public required string Role { get; set; }

    // Relace: Jeden zaměstnanec může být přiřazen k více lokacím (Many-To-Many)
    public List<LocationAssignment> LocationAssignments { get; set; } = new();
}
