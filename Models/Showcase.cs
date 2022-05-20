using System.ComponentModel.DataAnnotations;

namespace HALFFLUX_main_website.Models;

public class Showcase
{
    [Required]
    public int ID { get; set; }
    
    public string URL { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    
}