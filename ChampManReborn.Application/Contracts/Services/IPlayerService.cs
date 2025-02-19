using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface IPlayerService
{
    Task<IEnumerable<Player?>> GetAllPlayersAsync();
    Task<Player?> GetPlayerByIdAsync(Guid id);
    Task AddPlayerAsync(Player? player);
    Task UpdatePlayerAsync(Player? player);
    Task DeletePlayerAsync(Guid id);
}
