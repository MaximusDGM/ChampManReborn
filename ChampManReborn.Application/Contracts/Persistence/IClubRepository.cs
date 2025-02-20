using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface IClubRepository
{
    Task<IEnumerable<Club?>> GetAllAsync();
    Task<Club?> GetByIdAsync(Guid id);
    Task AddAsync(Club? team);
    Task UpdateAsync(Club club);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Club?>> GetClubsByLeagueIdAsync(Guid leagueId);
}