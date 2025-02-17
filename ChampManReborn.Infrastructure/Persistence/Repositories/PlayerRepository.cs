using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly DbContext _dbContext;

    public PlayerRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await _dbContext.Set<Player>().ToListAsync();
    }

    public async Task<Player> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<Player>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Player player)
    {
        await _dbContext.Set<Player>().AddAsync(player);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Player player)
    {
        var existingPlayer = await _dbContext.Set<Player>().FirstOrDefaultAsync(p => p.Id == player.Id);
        if (existingPlayer == null)
        {
            return;
        }

        existingPlayer.Name = player.Name;
        existingPlayer.Age = player.Age;

        _dbContext.Set<Player>().Update(existingPlayer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var player = await _dbContext.Set<Player>().FirstOrDefaultAsync(p => p.Id == id);
        if (player != null)
        {
            _dbContext.Set<Player>().Remove(player);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(Guid teamId)
    {
        return await _dbContext.Set<Player>()
            .Where(p => p.Id == teamId)
            .ToListAsync();
    }
}