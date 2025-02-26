using System.ComponentModel.DataAnnotations;

namespace DHL.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }  // Jméno zaměstnance

    [Required, EmailAddress]
    public required string Email { get; set; }  // E-mail zaměstnance

    [Required]
    public required string Role { get; set; }  // Role zaměstnance

    // Relace: Jeden zaměstnanec může být přiřazen k více lokacím (Many-To-Many)
    public List<LocationAssignment> LocationAssignments { get; set; } = new();
}
