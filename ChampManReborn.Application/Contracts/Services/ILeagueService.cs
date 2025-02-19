using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface ILeagueService
{
    Task<IEnumerable<League>> GetAllLeaguesAsync();
    Task<League> GetLeagueByIdAsync(Guid id);
    Task AddLeagueAsync(League league);
    Task UpdateLeagueAsync(League league);
    Task DeleteLeagueAsync(Guid id);
}
