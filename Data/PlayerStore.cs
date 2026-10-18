using wt_lab5_5razor_denisenko.Models;

namespace wt_lab5_5razor_denisenko.Data;

/// <summary>
/// Общее хранилище данных в памяти процесса. После перезапуска приложения
/// изменения, внесённые пользователем, сбрасываются к начальному набору.
/// </summary>
public static class PlayerStore
{
    public static List<Player> Players { get; } = new()
    {
        new Player { Id = 1, Nickname = "CyberWolf",  Game = "Counter-Strike 2", Rating = 1500, Wins = 24, Losses = 12, CreatedAt = new DateTime(2026, 9, 1) },
        new Player { Id = 2, Nickname = "ShadowFox",  Game = "Counter-Strike 2", Rating = 1750, Wins = 31, Losses = 10, CreatedAt = new DateTime(2026, 9, 2) },
        new Player { Id = 3, Nickname = "NeoMaster",  Game = "Dota 2",           Rating = 2100, Wins = 38, Losses = 9,  CreatedAt = new DateTime(2026, 9, 3) },
        new Player { Id = 4, Nickname = "DarkKnight", Game = "Dota 2",           Rating = 1850, Wins = 29, Losses = 15, CreatedAt = new DateTime(2026, 9, 4) },
        new Player { Id = 5, Nickname = "PixelHunter",Game = "Valorant",         Rating = 1600, Wins = 21, Losses = 18, CreatedAt = new DateTime(2026, 9, 5) },
        new Player { Id = 6, Nickname = "IceStorm",   Game = "Valorant",         Rating = 1900, Wins = 34, Losses = 11, CreatedAt = new DateTime(2026, 9, 6) },
        new Player { Id = 7, Nickname = "RedDragon",  Game = "Counter-Strike 2", Rating = 1250, Wins = 15, Losses = 20, CreatedAt = new DateTime(2026, 9, 7) }
    };
}
