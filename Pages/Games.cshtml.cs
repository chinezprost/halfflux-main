using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using HALFFLUX_main_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HALFFLUX_main_website.Pages;

public class GamesModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly ApplicationContexts _db;

    [BindProperty] public string URL { get; set; }

    [BindProperty] public string Title { get; set; }

    [BindProperty] public string Description { get; set; }
    
    [BindProperty] public int ShowcaseToDelete { get; set; }

    public List<Showcase> Showcases { get; set; }



    public GamesModel(ILogger<PrivacyModel> logger, ApplicationContexts db)
    {
        _logger = logger;
        _db = db;
    }


    public async Task<IActionResult> OnPostDeleteShowcase()
    {
        var showcaseToDelete = await _db.Showcases.FirstOrDefaultAsync(x => x.ID == ShowcaseToDelete);
        Console.WriteLine($"HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH {ShowcaseToDelete}");
        if (showcaseToDelete != null)
        {
            _db.Showcases.Remove(showcaseToDelete);
            await _db.SaveChangesAsync();
        }
        
        return RedirectToPage("Games", "Get");
    }
    
    
    public async Task<IActionResult> OnPostCreateShowcase()
    {

        Console.WriteLine($"{URL} + {Description} + {Title}");
        Showcase showcaseToAdd = new Showcase
        {
            URL = this.URL,
            Title = this.Title,
            Description = this.Description
        };
        await _db.Showcases.AddAsync(showcaseToAdd);
        await _db.SaveChangesAsync();


        Console.WriteLine("Added");
        return RedirectToPage("Games", "Get");
    }

    public async Task<IActionResult> OnGet()
    {
        try
        {
            Console.Write("GET EXECUTED");
            var showcase = await _db.Showcases.ToListAsync();

            if (showcase != null && showcase.Count > 0)
                Showcases = showcase;
        }
        catch (Exception _ex)
        {
            Console.WriteLine(_ex.ToString());
        }

        return Page();

    }

    public string ReturnVideoID(string URL)
    { 
        var uri = new Uri(URL); 
        var videoID = HttpUtility.ParseQueryString(uri.Query)["v"];
        return videoID;
    }
    
}