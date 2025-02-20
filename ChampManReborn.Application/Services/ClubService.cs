using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class ClubService(IClubRepository clubRepository) : IClubService
{
    public async Task<IEnumerable<Club?>> GetAllClubsAsync()
    {
        return await clubRepository.GetAllAsync();
    }

    public async Task<Club?> GetClubByIdAsync(Guid id)
    {
        return await clubRepository.GetByIdAsync(id);
    }

    public async Task AddClubAsync(Club? team)
    {
        await clubRepository.AddAsync(team);
    }

    public async Task UpdateClubAsync(Club club)
    {
        await clubRepository.UpdateAsync(club);
    }

    public async Task DeleteClubAsync(Guid id)
    {
        var club = await clubRepository.GetByIdAsync(id);
        if (club != null)
        {
            await clubRepository.DeleteAsync(id);
        }
    }
}
