using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class MatchService(IMatchRepository matchRepository) : IMatchService
{
    public async Task<IEnumerable<Match?>> GetAllMatchesAsync()
    {
        return await matchRepository.GetAllAsync();
    }

    public async Task<Match?> GetMatchByIdAsync(Guid id)
    {
        return await matchRepository.GetByIdAsync(id);
    }

    public async Task AddMatchAsync(Match? match)
    {
        await matchRepository.AddAsync(match);
    }

    public async Task UpdateMatchAsync(Match match)
    {
        await matchRepository.UpdateAsync(match);
    }

    public async Task DeleteMatchAsync(Guid id)
    {
        var match = await matchRepository.GetByIdAsync(id);
        if (match != null)
        {
            await matchRepository.DeleteAsync(id);
        }
    }
}
