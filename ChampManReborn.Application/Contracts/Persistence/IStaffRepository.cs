using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Contracts.Persistence;

public interface IStaffRepository
{
    Task<IEnumerable<Staff>> GetAllAsync();
    Task<Staff> GetByIdAsync(Guid id);
    Task AddAsync(Staff? staff);
    Task UpdateAsync(Staff staff);
    Task DeleteAsync(Guid id);
}