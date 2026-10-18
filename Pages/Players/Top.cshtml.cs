using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages.Players;

public class TopModel : PageModel
{
    public List<Player> Players { get; private set; } = new();

    public void OnGet()
    {
        Players = PlayerStore.Players.OrderByDescending(x => x.Rating).Take(3).ToList();
    }
}
