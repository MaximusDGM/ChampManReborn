using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Repositories;

public class TeamRepository(ChampManRebornContext dbContext) : ITeamRepository
{
    public async Task<IEnumerable<Team?>> GetAllAsync()
    {
        return await dbContext.Teams.ToListAsync();
    }

    public async Task<Team?> GetByIdAsync(Guid id)
    {
        return await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Team? team)
    {
        await dbContext.Teams.AddAsync(team);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Team team)
    {
        var existingTeam = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == team.Id);
        if (existingTeam == null)
        {
            return;
        }
        
        existingTeam.Name = team.Name;

        dbContext.Teams.Update(existingTeam);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == id);
        if (team != null)
        {
            dbContext.Teams.Remove(team);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Team?>> GetTeamsByLeagueIdAsync(Guid leagueId)
    {
        return await dbContext.Teams
            .Where(t => t.Id == leagueId)
            .ToListAsync();
    }
}