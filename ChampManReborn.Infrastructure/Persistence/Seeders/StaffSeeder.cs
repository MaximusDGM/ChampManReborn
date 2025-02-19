using Bogus;
using ChampManReborn.Domain.Entities;
using ChampManReborn.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Seeders;

public class StaffSeeder(ChampManRebornContext dbContext)
{
    public async Task SeedStaffsAsync()
    {
        if (await dbContext.Staff.AnyAsync())
            return;

        var nations = await dbContext.Nations.ToListAsync();

        var staffFaker = new Faker<Staff>()
            .RuleFor(s => s.Id, _ => Guid.NewGuid())
            .RuleFor(s => s.FirstName, f => f.Name.FirstName())
            .RuleFor(s => s.SecondName, f => f.Name.LastName())
            .RuleFor(s => s.CommonName, (f, s) => $"{s.FirstName} {s.SecondName}")
            .RuleFor(s => s.DateOfBirth, f => f.Date.Past(50, DateTime.UtcNow.AddYears(-20))) // Between 20-50 years old
            .RuleFor(s => s.YearOfBirth, (f, s) => s.DateOfBirth?.Year)
            .RuleFor(s => s.Nation, f => f.PickRandom(nations))
            .RuleFor(s => s.SecondNation, f => f.PickRandom(nations))
            .RuleFor(s => s.Adaptability, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Ambition, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Determination, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Loyalty, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Pressure, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Professionalism, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Sportsmanship, f => f.Random.Int(1, 20))
            .RuleFor(s => s.Temperament, f => f.Random.Int(1, 20))
            .RuleFor(s => s.PlayerData, _ => null);

        var fakeStaffs = staffFaker.Generate(50);
        await dbContext.Staff.AddRangeAsync(fakeStaffs);
        await dbContext.SaveChangesAsync();
    }
}