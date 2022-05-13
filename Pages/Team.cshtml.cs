using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Pages;

public class TeamModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public TeamModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}