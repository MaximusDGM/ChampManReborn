﻿using ChampManReborn.Application.Contracts.Persistence;
using ChampManReborn.Infrastructure.Contexts;
using ChampManReborn.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ChampManRebornContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IClubRepository, ClubRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<ILeagueRepository, LeagueRepository>();

        return services;
    }
}