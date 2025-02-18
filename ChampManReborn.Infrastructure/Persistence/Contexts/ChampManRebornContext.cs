using ChampManReborn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManReborn.Infrastructure.Contexts;

public class ChampManRebornContext : DbContext
{
    public ChampManRebornContext(DbContextOptions<ChampManRebornContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<League> Leagues { get; set; }
}