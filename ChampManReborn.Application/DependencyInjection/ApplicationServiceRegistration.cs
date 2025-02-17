using ChampManReborn.Application.Contracts.Services;
using ChampManReborn.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChampManReborn.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    // Convert the method into an extension method
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPlayerService, PlayerService>();
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<IMatchService, MatchService>();
        services.AddScoped<ILeagueService, LeagueService>();

        return services;
    }
}