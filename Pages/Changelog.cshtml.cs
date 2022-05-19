using System.ComponentModel;
using FireSharp.Config;
using HALFFLUX_main_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HALFFLUX_main_website.Pages;

public class ChangelogModel : PageModel
{

    private readonly ApplicationContexts _db;
    private readonly ILogger<PrivacyModel> _logger;
    public ChangelogModel(ILogger<PrivacyModel> logger, ApplicationContexts db)
    {
        _logger = logger;
        _db = db;
    }

    private FirebaseConfig _config = new FirebaseConfig
    {
        AuthSecret = "",
        BasePath = "https://halfflux-35e11-default-rtdb.europe-west1.firebasedatabase.app/"
    };
    
    public IActionResult OnButtonPress(string button)
    {
        Console.WriteLine("hello");
        return Page();
    }

    [BindProperty] 
    public List<ChangelogToShow> ChangelogsModal { get; set; }
    
    public List<ChangelogToShow> Changelogs = new List<ChangelogToShow>();


    public IActionResult OnPostButtonPress()
    {
        return RedirectToPage("Changelog/Add", "AddChangelogGet");
    }

    public async Task<IActionResult> OnGet()
    {
        Console.WriteLine("a");
        var changelogs = await _db.Changelogs.ToListAsync();
        for (int i = 0; i < changelogs.Count; i++)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == changelogs[i].UserId);
            if (user == null) 
                return Page();
            
            Changelogs.Add(new ChangelogToShow
            {
                Content = changelogs[i],
                Username = user.Username,
                UsernamePicture = user.UsernamePicture
            });
        }

        var aux = Changelogs.OrderByDescending(x => x.Content.Id).ToList();
        ChangelogsModal = aux;
        return Page();
    }


    public class ChangelogToShow
    {
        public string Username { get; set; }
        public string UsernamePicture { get; set; }
        public Models.Changelog Content { get; set; }

    }
}