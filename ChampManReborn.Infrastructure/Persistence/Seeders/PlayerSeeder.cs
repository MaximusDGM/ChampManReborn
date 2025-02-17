using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Seeders;

public class PlayerSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedPlayersAsync()
    {
        if (await dbContext.Players.AnyAsync())
            return;

        var playerFaker = new Faker<Player>()
            .RuleFor(p => p.Id, _ => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Name.FullName())
            .RuleFor(p => p.Age, f => f.Random.Int(18, 35))
            .RuleFor(p => p.Position, f => f.PickRandom("Goalkeeper", "Defender", "Midfielder", "Forward"));

        var fakePlayers = playerFaker.Generate(50);
        await dbContext.Players.AddRangeAsync(fakePlayers);
        await dbContext.SaveChangesAsync();
    }
}