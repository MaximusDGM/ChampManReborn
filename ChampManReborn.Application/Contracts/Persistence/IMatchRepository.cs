using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface IMatchRepository
{
    Task<IEnumerable<Match?>> GetAllAsync();
    Task<Match?> GetByIdAsync(Guid id);
    Task AddAsync(Match? match);
    Task UpdateAsync(Match match);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Match?>> GetMatchesByTeamIdAsync(Guid teamId);
}
