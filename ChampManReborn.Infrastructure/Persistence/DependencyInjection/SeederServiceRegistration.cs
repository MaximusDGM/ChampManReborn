using ChampManReborn.Infrastructure.Seeders;

namespace ChampManReborn.Infrastructure.DependencyInjection;

public static class SeederServiceRegistration
{
    public static IServiceCollection AddSeederServices(this IServiceCollection services)
    {
        services.AddScoped<PlayerSeeder>();
        services.AddScoped<ClubSeeder>();
        services.AddScoped<MatchSeeder>();
        services.AddScoped<LeagueSeeder>();
        services.AddScoped<DevelopmentDbSeeder>();

        return services;
    }
    
    public static async Task ApplySeederLogicAsync(this IServiceProvider serviceProvider, IHostEnvironment environment)
    {
        if (!environment.IsDevelopment()) return;

        using var scope = serviceProvider.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<DevelopmentDbSeeder>>();
        var seeder = scope.ServiceProvider.GetRequiredService<DevelopmentDbSeeder>();

        try
        {
            logger.LogInformation("Starting database seeding...");
            await seeder.SeedDatabaseAsync(); // Execute the seeding logic
            logger.LogInformation("Database seeding completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during the seeding process.");
            throw;
        }
    }

}