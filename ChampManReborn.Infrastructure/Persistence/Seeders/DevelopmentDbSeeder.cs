namespace ChampManReborn.Infrastructure.Seeders;

public class DevelopmentDbSeeder(
    PlayerSeeder playerSeeder,
    TeamSeeder teamSeeder,
    MatchSeeder matchSeeder,
    ILogger<DevelopmentDbSeeder> logger)
{
    public async Task SeedDatabaseAsync()
    {
        logger.LogInformation("Starting to seed the database...");

        await teamSeeder.SeedTeamsAsync();
        logger.LogInformation("Teams seeded.");

        await playerSeeder.SeedPlayersAsync();
        logger.LogInformation("Players seeded.");

        await matchSeeder.SeedMatchesAsync();
        logger.LogInformation("Fixtures seeded.");

        logger.LogInformation("Database seeding completed.");
    }
}