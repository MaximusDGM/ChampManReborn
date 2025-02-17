using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Persistence.Seeders
{
    public class TeamSeeder(ChampManRebornContext dbContext)
    {
        public async Task SeedTeamsAsync()
        {
            if (await dbContext.Teams.AnyAsync())
                return;

            var teamFaker = new Faker<Team>()
                .RuleFor(t => t.Id, _ => Guid.NewGuid())
                .RuleFor(t => t.Name, f => f.Company.CompanyName());
            var fakeTeams = teamFaker.Generate(10);
            await dbContext.Teams.AddRangeAsync(fakeTeams);
            await dbContext.SaveChangesAsync();
        }
    }
}