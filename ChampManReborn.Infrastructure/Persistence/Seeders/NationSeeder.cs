using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Seeders;

public class NationSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedNationsAsync()
    {
        if (await dbContext.Nations.AnyAsync())
            return;

        var nationFaker = new Faker<Nation>()
            .RuleFor(n => n.Id, _ => Guid.NewGuid())
            .RuleFor(n => n.Name, f => f.Address.Country())
            .RuleFor(n => n.ShortName, (f, n) => n.Name?.Substring(0, Math.Min(3, n.Name.Length)).ToUpper())
            .RuleFor(n => n.NameThreeLetter, f => f.Random.AlphaNumeric(3).ToUpper())
            .RuleFor(n => n.NameNationality, f => f.Name.JobArea() + "ian")
            .RuleFor(n => n.Continent, f => f.Random.Int(1, 6))
            .RuleFor(n => n.CapitalCity, f => f.Random.Number(1, 100))
            .RuleFor(n => n.NumberClubs, f => f.Random.Short(5, 50))
            .RuleFor(n => n.NumberStaff, f => f.Random.Int(50, 500))
            .RuleFor(n => n.Reputation, f => f.Random.Short(50, 100));

        var fakeNations = nationFaker.Generate(10);
        await dbContext.Nations.AddRangeAsync(fakeNations);
        await dbContext.SaveChangesAsync();
    }
}