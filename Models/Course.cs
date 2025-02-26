using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Models;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string CourseName { get; set; }  // Název kurzu

    public string? Description { get; set; }  // Volitelný popis kurzu

    public DateTime StartDate { get; set; } = DateTime.UtcNow;  // Datum začátku kurzu

    public DateTime? EndDate { get; set; }  // Datum ukončení (může být null)

    // Cizí klíč na lokaci, kde se kurz koná
    [ForeignKey("Location")]
    public int LocationId { get; set; }
    public required Location Location { get; set; }  // Navigační vlastnost
}
