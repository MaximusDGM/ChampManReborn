using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team> GetByIdAsync(Guid id);
    Task AddAsync(Team team);
    Task UpdateAsync(Team team);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Team>> GetTeamsByLeagueIdAsync(Guid leagueId);
}