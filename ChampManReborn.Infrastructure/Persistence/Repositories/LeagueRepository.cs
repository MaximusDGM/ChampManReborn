using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class LeagueRepository(ChampManRebornContext champManRebornContext) : ILeagueRepository
{
    public async Task<IEnumerable<League?>> GetAllAsync()
    {
        return await champManRebornContext.Leagues.ToListAsync();
    }

    public async Task<League?> GetByIdAsync(Guid id)
    {
        return await champManRebornContext.Leagues.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task AddAsync(League? league)
    {
        await champManRebornContext.Leagues.AddAsync(league);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(League league)
    {
        var existingLeague = await champManRebornContext.Leagues.FirstOrDefaultAsync(l => l != null && l.Id == league.Id);
        if (existingLeague == null)
        {
            return;
        }

        existingLeague.Name = league.Name;

        champManRebornContext.Leagues.Update(existingLeague);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var league = await champManRebornContext.Leagues.FirstOrDefaultAsync(l => l != null && l.Id == id);
        if (league != null)
        {
            champManRebornContext.Leagues.Remove(league);
            await champManRebornContext.SaveChangesAsync();
        }
    }
}