using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface INationService
{
    Task<IEnumerable<Nation?>> GetAllNationsAsync();
    Task<Nation?> GetNationByIdAsync(Guid id);
    Task AddNationAsync(Nation nation);
    Task UpdateNationAsync(Nation? nation);
    Task DeleteNationAsync(Guid id);
}