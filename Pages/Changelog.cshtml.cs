using System.ComponentModel;
using FireSharp.Config;
using HALFFLUX_main_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
    

    [BindProperty] 
    public List<ChangelogToShow> ChangelogsModal { get; set; }
    
    public List<ChangelogToShow> Changelogs = new List<ChangelogToShow>();
    
   

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
        ChangelogsModal = Changelogs;
        return Page();
    }


    public class ChangelogToShow
    {
        public string Username { get; set; }
        public string UsernamePicture { get; set; }
        public Changelog Content { get; set; }

    }
}