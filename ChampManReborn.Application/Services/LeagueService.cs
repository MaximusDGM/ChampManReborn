using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class LeagueService : ILeagueService
{
    private readonly ILeagueRepository _leagueRepository;

    public LeagueService(ILeagueRepository leagueRepository)
    {
        _leagueRepository = leagueRepository;
    }

    public async Task<IEnumerable<League?>> GetAllLeaguesAsync()
    {
        return await _leagueRepository.GetAllAsync();
    }

    public async Task<League?> GetLeagueByIdAsync(Guid id)
    {
        return await _leagueRepository.GetByIdAsync(id);
    }

    public async Task AddLeagueAsync(League? league)
    {
        await _leagueRepository.AddAsync(league);
    }

    public async Task UpdateLeagueAsync(League league)
    {
        await _leagueRepository.UpdateAsync(league);
    }

    public async Task DeleteLeagueAsync(Guid id)
    {
        var league = await _leagueRepository.GetByIdAsync(id);
        if (league != null)
        {
            await _leagueRepository.DeleteAsync(id);
        }
    }
}
