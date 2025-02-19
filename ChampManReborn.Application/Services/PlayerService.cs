using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
{
    public async Task<IEnumerable<Player?>> GetAllPlayersAsync()
    {
        return await playerRepository.GetAllAsync();
    }

    public async Task<Player?> GetPlayerByIdAsync(Guid id)
    {
        return await playerRepository.GetByIdAsync(id);
    }

    public async Task AddPlayerAsync(Player? player)
    {
        await playerRepository.AddAsync(player);
    }

    public async Task UpdatePlayerAsync(Player? player)
    {
        await playerRepository.UpdateAsync(player);
    }

    public async Task DeletePlayerAsync(Guid id)
    {
        var player = await playerRepository.GetByIdAsync(id);
        if (player != null)
        {
            await playerRepository.DeleteAsync(id);
        }
    }
}
