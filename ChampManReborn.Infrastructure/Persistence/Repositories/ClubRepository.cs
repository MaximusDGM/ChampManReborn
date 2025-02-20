using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Repositories;

public class ClubRepository(ChampManRebornContext dbContext) : IClubRepository
{
    public async Task<IEnumerable<Club?>> GetAllAsync()
    {
        return await dbContext.Clubs.ToListAsync();
    }

    public async Task<Club?> GetByIdAsync(Guid id)
    {
        return await dbContext.Clubs.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Club? club)
    {
        await dbContext.Clubs.AddAsync(club);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Club club)
    {
        var existingClub = await dbContext.Clubs.FirstOrDefaultAsync(t => t.Id == club.Id);
        if (existingClub == null)
        {
            return;
        }
        
        existingClub.Name = club.Name;

        dbContext.Clubs.Update(existingClub);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var club = await dbContext.Clubs.FirstOrDefaultAsync(t => t.Id == id);
        if (club != null)
        {
            dbContext.Clubs.Remove(club);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Club?>> GetClubsByLeagueIdAsync(Guid leagueId)
    {
        return await dbContext.Clubs
            .Where(t => t.Id == leagueId)
            .ToListAsync();
    }
}