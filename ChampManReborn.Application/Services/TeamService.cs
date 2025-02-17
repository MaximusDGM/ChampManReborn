using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;

    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Team?>> GetAllTeamsAsync()
    {
        return await _teamRepository.GetAllAsync();
    }

    public async Task<Team?> GetTeamByIdAsync(Guid id)
    {
        return await _teamRepository.GetByIdAsync(id);
    }

    public async Task AddTeamAsync(Team? team)
    {
        await _teamRepository.AddAsync(team);
    }

    public async Task UpdateTeamAsync(Team team)
    {
        await _teamRepository.UpdateAsync(team);
    }

    public async Task DeleteTeamAsync(Guid id)
    {
        var team = await _teamRepository.GetByIdAsync(id);
        if (team != null)
        {
            await _teamRepository.DeleteAsync(id);
        }
    }
}
