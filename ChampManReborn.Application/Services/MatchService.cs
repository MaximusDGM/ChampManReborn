using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _matchRepository;

    public MatchService(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<IEnumerable<Match>> GetAllMatchesAsync()
    {
        return await _matchRepository.GetAllAsync();
    }

    public async Task<Match> GetMatchByIdAsync(Guid id)
    {
        return await _matchRepository.GetByIdAsync(id);
    }

    public async Task AddMatchAsync(Match match)
    {
        await _matchRepository.AddAsync(match);
    }

    public async Task UpdateMatchAsync(Match match)
    {
        await _matchRepository.UpdateAsync(match);
    }

    public async Task DeleteMatchAsync(Guid id)
    {
        var match = await _matchRepository.GetByIdAsync(id);
        if (match != null)
        {
            await _matchRepository.DeleteAsync(id);
        }
    }
}
