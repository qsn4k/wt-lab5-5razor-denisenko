
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages.Tournaments;

public class IndexModel : PageModel
{
    public List<Tournament> Tournaments { get; private set; } = new();

    public List<string> Games { get; private set; } = new();

    public List<string> Statuses { get; private set; } = new();

    public string? Search { get; private set; }

    public string? Game { get; private set; }

    public string? Status { get; private set; }

    public void OnGet(string? search, string? game, string? status)
    {
        var searchTerm = search?.Trim();
        var gameFilter = game?.Trim();
        var statusFilter = status?.Trim();

        Search = searchTerm;
        Game = gameFilter;
        Status = statusFilter;

        IEnumerable<Tournament> result = TournamentStore.Tournaments;

        // Поиск по названию турнира и игре.
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            result = result.Where(tournament =>
                tournament.Name.Contains(
                    searchTerm, StringComparison.OrdinalIgnoreCase)
                || tournament.Game.Contains(
                    searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        // Фильтрация по игровой дисциплине.
        if (!string.IsNullOrWhiteSpace(gameFilter))
        {
            result = result.Where(tournament =>
                tournament.Game.Equals(
                    gameFilter, StringComparison.OrdinalIgnoreCase));
        }

        // Фильтрация по статусу.
        if (!string.IsNullOrWhiteSpace(statusFilter))
        {
            result = result.Where(tournament =>
                tournament.Status.Equals(
                    statusFilter, StringComparison.OrdinalIgnoreCase));
        }

        // Сначала текущие турниры, затем предстоящие,
        // после них завершённые.
        Tournaments = result
            .OrderBy(tournament => tournament.Status switch
            {
                "Идёт" => 0,
                "Предстоящий" => 1,
                _ => 2
            })
            .ThenBy(tournament => tournament.StartDate)
            .ToList();

        Games = TournamentStore.Tournaments
            .Select(tournament => tournament.Game)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(item => item)
            .ToList();

        Statuses = new List<string>
        {
            "Идёт",
            "Предстоящий",
            "Завершён"
        };
    }
}
