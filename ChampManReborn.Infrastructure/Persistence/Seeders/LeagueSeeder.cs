using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Seeders;

public class LeagueSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedLeaguesAsync()
    {
        if (await dbContext.Leagues.AnyAsync())
            return;

        var leagueFaker = new Faker<League>()
            .RuleFor(l => l.Id, _ => Guid.NewGuid())
            .RuleFor(l => l.Name, f => f.Company.CompanyName());
        var fakeLeagues = leagueFaker.Generate(5);
        await dbContext.Leagues.AddRangeAsync(fakeLeagues);
        await dbContext.SaveChangesAsync();
    }
}