using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class TeamRepository(ChampManRebornContext dbContext) : ITeamRepository
{
    private readonly ChampManRebornContext _dbContext = dbContext;

    public Task<IEnumerable<Team>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Team> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Team team)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Team team)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetTeamsByLeagueIdAsync(Guid leagueId)
    {
        throw new NotImplementedException();
    }
}