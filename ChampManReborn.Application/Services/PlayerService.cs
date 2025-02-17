using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<IEnumerable<Player>> GetAllPlayersAsync()
    {
        return await _playerRepository.GetAllAsync();
    }

    public async Task<Player> GetPlayerByIdAsync(Guid id)
    {
        return await _playerRepository.GetByIdAsync(id);
    }

    public async Task AddPlayerAsync(Player player)
    {
        await _playerRepository.AddAsync(player);
    }

    public async Task UpdatePlayerAsync(Player player)
    {
        await _playerRepository.UpdateAsync(player);
    }

    public async Task DeletePlayerAsync(Guid id)
    {
        var player = await _playerRepository.GetByIdAsync(id);
        if (player != null)
        {
            await _playerRepository.DeleteAsync(id);
        }
    }
}
