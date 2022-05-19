using Microsoft.AspNetCore.Mvc;

namespace HALFFLUX_main_website.Controllers;

public class ChangelogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult OnButtonPress(string button)
    {
        Console.WriteLine("hello");
        return Ok();
    }
}