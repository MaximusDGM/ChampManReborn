using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface INationRepository
{
    Task<IEnumerable<Nation?>> GetAllAsync();
    Task<Nation?> GetByIdAsync(Guid id);
    Task AddAsync(Nation? nation);
    Task UpdateAsync(Nation? nation);
    Task DeleteAsync(Guid id);
}