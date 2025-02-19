using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Repositories;

public class MatchRepository(ChampManRebornContext champManRebornContext) : IMatchRepository
{
    public async Task<IEnumerable<Match?>> GetAllAsync()
    {
        return await champManRebornContext.Matches.ToListAsync();
    }

    public async Task<Match?> GetByIdAsync(Guid id)
    {
        return await champManRebornContext.Matches.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Match? match)
    {
        await champManRebornContext.Matches.AddAsync(match);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Match match)
    {
        var existingMatch = await champManRebornContext.Matches.FirstOrDefaultAsync(m => m != null && m.Id == match.Id);
        if (existingMatch == null)
        {
            return;
        }

        existingMatch.MatchDate = match.MatchDate;
        existingMatch.HomeTeamId = match.HomeTeamId;
        existingMatch.AwayTeamId = match.AwayTeamId;
        existingMatch.HomeScore = match.HomeScore;
        existingMatch.AwayScore = match.AwayScore;

        champManRebornContext.Matches.Update(existingMatch);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var match = await champManRebornContext.Matches.FirstOrDefaultAsync(m => m != null && m.Id == id);
        if (match != null)
        {
            champManRebornContext.Matches.Remove(match);
            await champManRebornContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Match?>> GetMatchesByTeamIdAsync(Guid teamId)
    {
        return await champManRebornContext.Matches
            .Where(m => m != null && (m.HomeTeamId == teamId || m.AwayTeamId == teamId))
            .ToListAsync();
    }
}