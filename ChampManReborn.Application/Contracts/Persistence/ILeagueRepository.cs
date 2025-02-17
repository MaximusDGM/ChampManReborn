using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface ILeagueRepository
{
    Task<IEnumerable<League?>> GetAllAsync();
    Task<League?> GetByIdAsync(Guid id);
    Task AddAsync(League? league);
    Task UpdateAsync(League league);
    Task DeleteAsync(Guid id);
}
