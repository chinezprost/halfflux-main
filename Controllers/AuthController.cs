using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Controllers;

public class AuthController : Controller
{
    [HttpPost]
    public ActionResult RegisterUser(string registerUsername, string registerPassword, string registerPasswordConfirm)
    {
        Console.WriteLine("AAAAAAAAAAAAAAAAAAAA");
        Console.WriteLine($"{registerUsername} - {registerPassword} - {registerPasswordConfirm}");
        return NotFound();
    }
}