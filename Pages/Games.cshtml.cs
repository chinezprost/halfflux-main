using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Pages;

public class GamesModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public GamesModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}