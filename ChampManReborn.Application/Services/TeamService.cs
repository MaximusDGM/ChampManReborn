using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class TeamService(ITeamRepository teamRepository) : ITeamService
{
    public async Task<IEnumerable<Team?>> GetAllTeamsAsync()
    {
        return await teamRepository.GetAllAsync();
    }

    public async Task<Team?> GetTeamByIdAsync(Guid id)
    {
        return await teamRepository.GetByIdAsync(id);
    }

    public async Task AddTeamAsync(Team? team)
    {
        await teamRepository.AddAsync(team);
    }

    public async Task UpdateTeamAsync(Team team)
    {
        await teamRepository.UpdateAsync(team);
    }

    public async Task DeleteTeamAsync(Guid id)
    {
        var team = await teamRepository.GetByIdAsync(id);
        if (team != null)
        {
            await teamRepository.DeleteAsync(id);
        }
    }
}
