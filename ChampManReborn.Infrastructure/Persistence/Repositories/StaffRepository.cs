using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Repositories;

public class StaffRepository(ChampManRebornContext champManRebornContext) : IStaffRepository
{
    public async Task<IEnumerable<Staff?>> GetAllAsync()
    {
        return await champManRebornContext.Staff.ToListAsync();
    }

    public async Task<Staff?> GetByIdAsync(Guid id)
    {
        return await champManRebornContext.Staff.FirstOrDefaultAsync(s => s.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(Staff? staff)
    {
        if (staff != null) await champManRebornContext.Staff.AddAsync(staff);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Staff staff)
    {
        var existingStaff = await champManRebornContext.Staff.FirstOrDefaultAsync(s => s.Id == staff.Id);
        if (existingStaff == null)
        {
            return;
        }

        existingStaff.FirstName = staff.FirstName;
        existingStaff.LastName = staff.LastName;

        champManRebornContext.Staff.Update(existingStaff);
        await champManRebornContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var staff = await champManRebornContext.Staff.FirstOrDefaultAsync(s => s.Id == id);
        if (staff != null)
        {
            champManRebornContext.Staff.Remove(staff);
            await champManRebornContext.SaveChangesAsync();
        }
    }
}