using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface IPlayerRepository
{
    Task<IEnumerable<Player?>> GetAllAsync();
    Task<Player?> GetByIdAsync(Guid id);
    Task AddAsync(Player? player);
    Task UpdateAsync(Player? player);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Player?>> GetPlayersByTeamIdAsync(Guid teamId);
}
