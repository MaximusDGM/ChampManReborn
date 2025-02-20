using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Seeders;

public class ClubSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedTeamsAsync()
    {
        if (await dbContext.Clubs.AnyAsync())
            return;

        var teamFaker = new Faker<Club>()
            .RuleFor(t => t.Id, _ => Guid.NewGuid())
            .RuleFor(t => t.Name, f => f.Company.CompanyName())
            .RuleFor(t => t.Stadium, f => f.Address.SecondaryAddress());
        var fakeTeams = teamFaker.Generate(10);
        await dbContext.Clubs.AddRangeAsync(fakeTeams);
        await dbContext.SaveChangesAsync();
    }
}