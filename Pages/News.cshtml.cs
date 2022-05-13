using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Pages;

public class NewsModal : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public NewsModal(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}