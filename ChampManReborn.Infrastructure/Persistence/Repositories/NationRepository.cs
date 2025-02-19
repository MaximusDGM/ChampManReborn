using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Repositories;

public class NationRepository(ChampManRebornContext champManRebornContext) : INationRepository
{
    public async Task<IEnumerable<Nation?>> GetAllAsync()
    {
        return await champManRebornContext.Nations.ToListAsync();
    }

    public async Task<Nation?> GetByIdAsync(Guid id)
    {
        return await champManRebornContext.Nations.FirstOrDefaultAsync(n => n.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Nation? nation)
    {
        if (nation != null) await champManRebornContext.Nations.AddAsync(nation);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Nation? nation)
    {
        var existingNation = await champManRebornContext.Nations.FirstOrDefaultAsync(n => n.Id == nation.Id);
        if (existingNation == null)
        {
            return;
        }

        existingNation.Name = nation.Name;
        existingNation.Continent = nation.Continent;
        existingNation.Reputation = nation.Reputation;

        champManRebornContext.Nations.Update(existingNation);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var nation = await champManRebornContext.Nations.FirstOrDefaultAsync(n => n.Id == id);
        if (nation != null)
        {
            champManRebornContext.Nations.Remove(nation);
            await champManRebornContext.SaveChangesAsync();
        }
    }
}