using Microsoft.EntityFrameworkCore;
using ChampManReborn.Domain.Entities;

namespace ChampManReborn.Infrastructure.Persistence.Contexts
{
    public class ChampManRebornContext(DbContextOptions<ChampManRebornContext> options) : DbContext(options)
    {
        // Database sets for entities (tables)
        public DbSet<Player> Players { get; set; }
        public DbSet<Team?> Teams { get; set; }
        public DbSet<Match?> Matches { get; set; }
        public DbSet<League?> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations (if any)
        }
    }
}