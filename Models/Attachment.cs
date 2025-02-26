using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DHL.Models;

public class Attachment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string FileName { get; set; }

    public required string FileType { get; set; }

    public required byte[] FileData { get; set; }

    // Relace: Každá příloha může patřit k reportu
    [ForeignKey("RegionalReport")]
    public int RegionalReportId { get; set; }

    public required RegionalReport RegionalReport { get; set; }
}
