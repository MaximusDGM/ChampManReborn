using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface IMatchService
{
    Task<IEnumerable<Match?>> GetAllMatchesAsync();
    Task<Match?> GetMatchByIdAsync(Guid id);
    Task AddMatchAsync(Match? match);
    Task UpdateMatchAsync(Match match);
    Task DeleteMatchAsync(Guid id);
}