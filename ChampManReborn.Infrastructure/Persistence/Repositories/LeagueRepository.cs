using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class LeagueRepository(ChampManRebornContext champManRebornContext) : ILeagueRepository
{
    private readonly ChampManRebornContext _champManRebornContext = champManRebornContext;

    public Task<IEnumerable<League>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<League> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(League league)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(League league)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}