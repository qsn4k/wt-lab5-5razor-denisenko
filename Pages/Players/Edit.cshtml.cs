using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages.Players;

public class EditModel : PageModel
{
    [BindProperty]
    public Player Player { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        var existing = PlayerStore.Players.FirstOrDefault(x => x.Id == id);
        if (existing is null)
        {
            return NotFound();
        }

        Player = new Player
        {
            Id = existing.Id,
            Nickname = existing.Nickname,
            Game = existing.Game,
            Rating = existing.Rating,
            Wins = existing.Wins,
            Losses = existing.Losses,
            CreatedAt = existing.CreatedAt
        };
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        if (id != Player.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var existing = PlayerStore.Players.FirstOrDefault(x => x.Id == id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.Nickname = Player.Nickname;
        existing.Game = Player.Game;
        existing.Rating = Player.Rating;
        existing.Wins = Player.Wins;
        existing.Losses = Player.Losses;

        TempData["SuccessMessage"] = $"Данные игрока «{existing.Nickname}» обновлены.";
        return RedirectToPage("./Details", new { id = existing.Id });
    }
}
