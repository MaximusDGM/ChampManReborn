using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Persistence.Repositories;

public class PlayerRepository(DbContext dbContext) : IPlayerRepository
{
    private readonly DbContext _dbContext = dbContext;

    public Task<IEnumerable<Player>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Player> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Player player)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Player player)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(Guid teamId)
    {
        throw new NotImplementedException();
    }
}
