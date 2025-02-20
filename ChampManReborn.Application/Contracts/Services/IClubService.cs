using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface IClubService
{
    Task<IEnumerable<Club?>> GetAllClubsAsync();
    Task<Club?> GetClubByIdAsync(Guid id);
    Task AddClubAsync(Club? team);
    Task UpdateClubAsync(Club club);
    Task DeleteClubAsync(Guid id);
}
