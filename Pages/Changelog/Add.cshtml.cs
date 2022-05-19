using System.Runtime.CompilerServices;
using HALFFLUX_main_website.Controllers;
using HALFFLUX_main_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Pages.Changelog;

public class Add : PageModel
{
    private readonly ApplicationContexts _db;
    
    public Add(ApplicationContexts db)
    {
        _db = db;
    }
    
    [BindProperty]
    public string ChangelogContent { get; set; }
    
    [BindProperty]
    public string ChangelogVersion { get; set; }


    public async Task<IActionResult> OnPostUploadChangelog()
    {
        if (ChangelogContent.Length > 0)
        {
            string[] version = ChangelogVersion.Split();
            
            var majorPatch = version[0];
            var mediumPatch = version[1];
            var minorPatch = version[2];
            
            Models.Changelog changelogToUpload = new Models.Changelog();
            try
            {
                changelogToUpload.ChangelogContent = ChangelogContent;
                changelogToUpload.UserId = 1;
                changelogToUpload.TimeStamp = DateTime.Now;
                changelogToUpload.MajorPatch = int.Parse(majorPatch);
                changelogToUpload.MediumPatch = int.Parse(mediumPatch);
                changelogToUpload.MinorPatch = int.Parse(minorPatch);

                await _db.Changelogs.AddAsync(changelogToUpload);
                await _db.SaveChangesAsync();
                Console.WriteLine("Uploaded changelog");

            }
            catch (Exception _ex)
            {
                Console.WriteLine(_ex.ToString());
            }
        }

        return RedirectToPage("/Changelog");
    }
}