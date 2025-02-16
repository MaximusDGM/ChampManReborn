using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class MatchRepository(ChampManRebornContext champManRebornContext) : IMatchRepository
{
    private readonly ChampManRebornContext _champManRebornContext = champManRebornContext;

    public Task<IEnumerable<Match>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Match> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Match match)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Match match)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Match>> GetMatchesByTeamIdAsync(Guid teamId)
    {
        throw new NotImplementedException();
    }
}