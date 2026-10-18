using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages.Players;

public class DetailsModel : PageModel
{
    public Player? Player { get; private set; }

    public IActionResult OnGet(int id)
    {
        Player = PlayerStore.Players.FirstOrDefault(x => x.Id == id);
        return Player is null ? NotFound() : Page();
    }

    public IActionResult OnPostDelete(int id)
    {
        var player = PlayerStore.Players.FirstOrDefault(x => x.Id == id);
        if (player is null)
        {
            return NotFound();
        }

        PlayerStore.Players.Remove(player);
        TempData["SuccessMessage"] = $"Игрок «{player.Nickname}» удалён.";
        return RedirectToPage("./Index");
    }
}
