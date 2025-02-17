using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Seeders;

public class MatchSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedMatchesAsync()
    {
        if (await dbContext.Matches.AnyAsync())
            return;

        var teams = await dbContext.Teams.ToListAsync();
        if (teams.Count < 2)
            throw new InvalidOperationException("At least 2 teams are required for matches.");

        var matchFaker = new Faker<Match>()
            .RuleFor(m => m.Id, _ => Guid.NewGuid())
            .RuleFor(m => m.HomeTeamId, f => f.PickRandom(teams).Id)
            .RuleFor(m => m.AwayTeamId, f => f.PickRandom(teams).Id)
            .RuleFor(m => m.MatchDate, f => f.Date.Between(DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(3)));

        var fakeMatches = matchFaker.Generate(20).Where(m => m.HomeTeamId != m.AwayTeamId).ToList();

        await dbContext.Matches.AddRangeAsync(fakeMatches);
        await dbContext.SaveChangesAsync();
    }
}