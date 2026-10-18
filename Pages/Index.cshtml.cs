using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages;

public class IndexModel : PageModel
{
    public int PlayerCount => PlayerStore.Players.Count;
    public int GameCount => PlayerStore.Players.Select(x => x.Game).Distinct(StringComparer.OrdinalIgnoreCase).Count();
    public int TotalWins => PlayerStore.Players.Sum(x => x.Wins);
    public List<Player> TopPlayers { get; private set; } = new();

    public void OnGet()
    {
        TopPlayers = PlayerStore.Players.OrderByDescending(x => x.Rating).Take(3).ToList();
    }
}
