using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_denisenko.Data;
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Pages.Players;

public class CreateModel : PageModel
{
    [BindProperty]
    public Player Player { get; set; } = new();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Player.Id = PlayerStore.Players.Count == 0 ? 1 : PlayerStore.Players.Max(x => x.Id) + 1;
        Player.CreatedAt = DateTime.Now;
        PlayerStore.Players.Add(Player);

        TempData["SuccessMessage"] = $"Игрок «{Player.Nickname}» успешно добавлен.";
        return RedirectToPage("./Index");
    }
}
