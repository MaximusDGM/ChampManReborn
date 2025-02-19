using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Application.Services;

public class StaffService(IStaffRepository staffRepository) : IStaffService
{
    public async Task<IEnumerable<Staff>> GetAllStaffAsync()
    {
        return await staffRepository.GetAllAsync();
    }

    public async Task<Staff> GetStaffByIdAsync(Guid id)
    {
        return await staffRepository.GetByIdAsync(id);
    }

    public async Task AddStaffAsync(Staff staff)
    {
        await staffRepository.AddAsync(staff);
    }

    public async Task UpdateStaffAsync(Staff staff)
    {
        await staffRepository.UpdateAsync(staff);
    }

    public async Task DeleteStaffAsync(Guid id)
    {
        var staff = await staffRepository.GetByIdAsync(id);
        if (staff != null)
        {
            await staffRepository.DeleteAsync(id);
        }
    }
}