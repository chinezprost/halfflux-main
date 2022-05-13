using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace HALFFLUX_main_website.Models;

public class Changelog
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int UserId { get; set; }

    [Required]
    public int MinorPatch { get; set; }
    [Required]
    public int MediumPatch { get; set; }
    [Required]
    public int MajorPatch { get; set; }
    [Required]
    public DateTime TimeStamp { get; set; }
    
    public string ChangelogContent { get; set; }
}