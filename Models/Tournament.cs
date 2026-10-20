
using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_denisenko.Models;

public class Tournament
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название турнира.")]
    [StringLength(80, MinimumLength = 3,
        ErrorMessage = "Название должно содержать от 3 до 80 символов.")]
    [Display(Name = "Название турнира")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите игру.")]
    [StringLength(60, MinimumLength = 2,
        ErrorMessage = "Название игры должно содержать от 2 до 60 символов.")]
    [Display(Name = "Игра")]
    public string Game { get; set; } = string.Empty;

    [Display(Name = "Дата начала")]
    public DateTime StartDate { get; set; }

    [Range(0, 512,
        ErrorMessage = "Количество участников должно быть от 0 до 512.")]
    [Display(Name = "Количество участников")]
    public int CurrentPlayers { get; set; }

    [Range(2, 512,
        ErrorMessage = "Вместимость должна быть от 2 до 512 участников.")]
    [Display(Name = "Максимальное количество участников")]
    public int MaxPlayers { get; set; }

    [Range(typeof(decimal), "0", "10000000",
        ErrorMessage = "Призовой фонд должен быть неотрицательным.")]
    [Display(Name = "Призовой фонд")]
    public decimal PrizePool { get; set; }

    [Required(ErrorMessage = "Укажите статус турнира.")]
    [Display(Name = "Статус")]
    public string Status { get; set; } = "Предстоящий";

    public int AvailableSlots =>
        Math.Max(0, MaxPlayers - CurrentPlayers);

    public double FillPercentage =>
        MaxPlayers <= 0
            ? 0
            : Math.Clamp(CurrentPlayers * 100.0 / MaxPlayers, 0, 100);
}
