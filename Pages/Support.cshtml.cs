using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HALFFLUX_main_website.Pages;

public class SupportModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public SupportModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}