using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Services;

public interface IStaffService
{
    Task<IEnumerable<Staff?>> GetAllStaffAsync();
    Task<Staff?> GetStaffByIdAsync(Guid id);
    Task AddStaffAsync(Staff staff);
    Task UpdateStaffAsync(Staff staff);
    Task DeleteStaffAsync(Guid id);
}