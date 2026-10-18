using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab5_5razor_denisenko.Pages;

public class ErrorModel : PageModel
{
    public string RequestId { get; private set; } = string.Empty;

    public void OnGet() => RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier;
}
