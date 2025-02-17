using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface ITeamService
{
    Task<IEnumerable<Team?>> GetAllTeamsAsync();
    Task<Team?> GetTeamByIdAsync(Guid id);
    Task AddTeamAsync(Team? team);
    Task UpdateTeamAsync(Team team);
    Task DeleteTeamAsync(Guid id);
}
