using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Infrastructure.Persistence.Contexts;
using ChampManReborn.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Persistence.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database context registration (using Entity Framework Core)
        services.AddDbContext<ChampManRebornContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register repositories
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<ILeagueRepository, LeagueRepository>();

        return services;
    }
}