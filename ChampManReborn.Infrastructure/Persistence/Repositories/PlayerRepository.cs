using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly List<Player> _mockPlayers =
    [
        new() { Id = Guid.NewGuid(), Name = "Player 1", Age = 25 },
        new() { Id = Guid.NewGuid(), Name = "Player 2", Age = 28 },
        new() { Id = Guid.NewGuid(), Name = "Player 3", Age = 22 }
    ];

    public Task<IEnumerable<Player>> GetAllAsync()
    {
        return Task.FromResult(_mockPlayers.AsEnumerable());
    }

    public Task<Player?> GetByIdAsync(Guid id)
    {
        var player = _mockPlayers.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(player);
    }

    public Task AddAsync(Player player)
    {
        _mockPlayers.Add(player);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Player player)
    {
        var existingPlayer = _mockPlayers.FirstOrDefault(p => p.Id == player.Id);
        if (existingPlayer != null)
        {
            existingPlayer.Name = player.Name;
            existingPlayer.Age = player.Age;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var player = _mockPlayers.FirstOrDefault(p => p.Id == id);
        if (player != null)
        {
            _mockPlayers.Remove(player);
        }
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(Guid teamId)
    {
        var players = _mockPlayers.Where(p => p.Id == teamId);
        return Task.FromResult(players.AsEnumerable());
    }
}