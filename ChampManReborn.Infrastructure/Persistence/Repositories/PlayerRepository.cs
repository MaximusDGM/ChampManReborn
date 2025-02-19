using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class PlayerRepository(ChampManRebornContext dbContext) : IPlayerRepository
{
    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await dbContext.Players.ToListAsync();
    }

    public async Task<Player?> GetByIdAsync(Guid id)
    {
        return await dbContext.Players.FindAsync(id);
    }

    public async Task AddAsync(Player player)
    {
        await dbContext.Players.AddAsync(player);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Player player)
    {
        dbContext.Players.Update(player);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var player = await dbContext.Players.FindAsync(id);
        if (player != null)
        {
            dbContext.Players.Remove(player);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(Guid teamId)
    {
        return await dbContext.Players.Where(p => ((Person)p).Id == teamId).ToListAsync();
    }
}