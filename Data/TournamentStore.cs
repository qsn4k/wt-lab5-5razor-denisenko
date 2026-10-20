
using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Data;

public static class TournamentStore
{
    public static List<Tournament> Tournaments { get; } = new()
    {
        new Tournament
        {
            Id = 1,
            Name = "Cyber Cup: Autumn Split",
            Game = "Counter-Strike 2",
            StartDate = new DateTime(2026, 10, 24, 16, 0, 0),
            CurrentPlayers = 18,
            MaxPlayers = 32,
            PrizePool = 500m,
            Status = "Предстоящий"
        },
        new Tournament
        {
            Id = 2,
            Name = "Dota Arena: Season 4",
            Game = "Dota 2",
            StartDate = new DateTime(2026, 10, 26, 18, 0, 0),
            CurrentPlayers = 12,
            MaxPlayers = 16,
            PrizePool = 350m,
            Status = "Предстоящий"
        },
        new Tournament
        {
            Id = 3,
            Name = "Neon Masters",
            Game = "Valorant",
            StartDate = new DateTime(2026, 10, 28, 17, 0, 0),
            CurrentPlayers = 24,
            MaxPlayers = 32,
            PrizePool = 750m,
            Status = "Предстоящий"
        },
        new Tournament
        {
            Id = 4,
            Name = "Night League",
            Game = "Counter-Strike 2",
            StartDate = new DateTime(2026, 10, 19, 19, 0, 0),
            CurrentPlayers = 14,
            MaxPlayers = 16,
            PrizePool = 250m,
            Status = "Идёт"
        },
        new Tournament
        {
            Id = 5,
            Name = "Autumn Finals",
            Game = "Dota 2",
            StartDate = new DateTime(2026, 10, 12, 15, 0, 0),
            CurrentPlayers = 16,
            MaxPlayers = 16,
            PrizePool = 1000m,
            Status = "Завершён"
        }
    };
}
