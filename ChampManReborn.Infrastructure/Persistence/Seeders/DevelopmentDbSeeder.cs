namespace ChampManReborn.Infrastructure.Seeders;

public class DevelopmentDbSeeder(
    PlayerSeeder playerSeeder,
    ClubSeeder clubSeeder,
    MatchSeeder matchSeeder,
    LeagueSeeder leagueSeeder,
    NationSeeder nationSeeder,
    StaffSeeder staffSeeder,
    ILogger<DevelopmentDbSeeder> logger)
{
    public async Task SeedDatabaseAsync()
    {
        logger.LogInformation("Starting to seed the database...");
        
        await nationSeeder.SeedNationsAsync();
        logger.LogInformation("Nations seeded.");

        await staffSeeder.SeedStaffsAsync();
        logger.LogInformation("Staff seeded.");

        await clubSeeder.SeedTeamsAsync();
        logger.LogInformation("Clubs seeded.");

        await playerSeeder.SeedPlayersAsync();
        logger.LogInformation("Players seeded.");

        await matchSeeder.SeedMatchesAsync();
        logger.LogInformation("Fixtures seeded.");
        
        await leagueSeeder.SeedLeaguesAsync();
        logger.LogInformation("Leagues seeded.");

        logger.LogInformation("Database seeding completed.");
    }
}