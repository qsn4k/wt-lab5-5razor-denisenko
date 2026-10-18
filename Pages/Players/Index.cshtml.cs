using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages.Players;

public class IndexModel : PageModel
{
    public List<Player> Players { get; private set; } = new();
    public List<string> Games { get; private set; } = new();
    public string? Search { get; private set; }
    public string? Game { get; private set; }

    public void OnGet(string? search, string? game)
    {
        Search = search?.Trim();
        Game = game;
        IEnumerable<Player> result = PlayerStore.Players;

        if (!string.IsNullOrWhiteSpace(Search))
        {
            result = result.Where(player => player.Nickname.Contains(Search, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(Game))
        {
            result = result.Where(player => player.Game.Equals(Game, StringComparison.OrdinalIgnoreCase));
        }

        Players = result.OrderByDescending(player => player.Rating).ToList();
        Games = PlayerStore.Players.Select(player => player.Game)
            .Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(item => item).ToList();
    }
}
