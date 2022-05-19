using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Controllers;

public class AuthController : Controller
{
    public IActionResult RegisterUser()
    {
        return RedirectToPage("Index");
    }
    [Route("Auth/RegisterUser")]
    [HttpPost]
    public IActionResult RegisterUser(string registerUsername, string registerPassword, string registerConfirmPassword)
    {
        Console.WriteLine("AAAAAAAAAAAAAAAAAAAA");
        Console.WriteLine($"{registerUsername} - {registerPassword} - {registerConfirmPassword}");
        return Ok();
    }

    
}