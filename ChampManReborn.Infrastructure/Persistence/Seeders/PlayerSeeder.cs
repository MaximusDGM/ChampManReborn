using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Person = ChampManReborn.Domain.Entities.Person;

namespace ChampManReborn.Infrastructure.Seeders;

public class PlayerSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedPlayersAsync()
    {
        if (await dbContext.Players.AnyAsync())
            return;

        var playerFaker = new Faker<Player>()
            .RuleFor(p => ((Person)p).Id, _ => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Name.FullName())
            .RuleFor(p => p.Age, f => f.Random.Int(18, 35))
            .RuleFor(p => p.SquadNumber, f => f.Random.Int(1, 99))
            .RuleFor(p => p.HomeReputation, f => (short)f.Random.Int(1, 10))
            .RuleFor(p => p.CurrentReputation, f => (short)f.Random.Int(1, 10))
            .RuleFor(p => p.WorldReputation, f => (short)f.Random.Int(1, 10))
            .RuleFor(p => p.Goalkeeper, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Sweeper, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Defender, f => f.Random.Int(0, 100))
            .RuleFor(p => p.DefensiveMidfielder, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Midfielder, f => f.Random.Int(0, 100))
            .RuleFor(p => p.AttackingMidfielder, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Attacker, f => f.Random.Int(0, 100))
            .RuleFor(p => p.WingBack, f => f.Random.Int(0, 100))
            .RuleFor(p => p.RightSide, f => f.Random.Int(0, 100))
            .RuleFor(p => p.LeftSide, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Central, f => f.Random.Int(0, 100))
            .RuleFor(p => p.FreeRole, f => f.Random.Int(0, 100))
            .RuleFor(p => p.Acceleration, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Aggression, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Agility, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Anticipation, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Balance, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Bravery, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Consistency, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Decisions, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Leadership, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Positioning, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Vision, f => f.Random.Int(1, 20))
            .RuleFor(p => p.WorkRate, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Stamina, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Strength, f => f.Random.Int(1, 20))
            .RuleFor(p => p.NaturalFitness, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Jumping, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Pace, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Reflexes, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Dribbling, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Finishing, f => f.Random.Int(1, 20))
            .RuleFor(p => p.FreeKicks, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Crossing, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Tackling, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Marking, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Passing, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Heading, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Penalties, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Corners, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Technique, f => f.Random.Int(1, 20))
            .RuleFor(p => p.LeftFoot, f => f.Random.Int(1, 20))
            .RuleFor(p => p.RightFoot, f => f.Random.Int(1, 20))
            .RuleFor(p => p.Morale, f => f.Random.Int(1, 20))
            .RuleFor(p => p.CurrentAbility, f => f.Random.Int(100, 200))
            .RuleFor(p => p.PotentialAbility, f => f.Random.Int(100, 200))
            .FinishWith((f, p) =>
            {
                p.PotentialAbility = f.Random.Int(p.CurrentAbility, 200);
            });

        var fakePlayers = playerFaker.Generate(50);
        await dbContext.Players.AddRangeAsync(fakePlayers);
        await dbContext.SaveChangesAsync();
    }
}