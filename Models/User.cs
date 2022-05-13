using System.ComponentModel.DataAnnotations;

namespace HALFFLUX_main_website.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    public string UsernamePicture { get; set; }
    
    public int IsDeveloper { get; set; }
}