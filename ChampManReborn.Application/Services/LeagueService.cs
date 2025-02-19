using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class LeagueService(ILeagueRepository leagueRepository) : ILeagueService
{
    public async Task<IEnumerable<League?>> GetAllLeaguesAsync()
    {
        return await leagueRepository.GetAllAsync();
    }

    public async Task<League?> GetLeagueByIdAsync(Guid id)
    {
        return await leagueRepository.GetByIdAsync(id);
    }

    public async Task AddLeagueAsync(League league)
    {
        await leagueRepository.AddAsync(league);
    }

    public async Task UpdateLeagueAsync(League league)
    {
        await leagueRepository.UpdateAsync(league);
    }

    public async Task DeleteLeagueAsync(Guid id)
    {
        await leagueRepository.DeleteAsync(id);
    }
}
