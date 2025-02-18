using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChampManReborn.Infrastructure.Contexts;

public class ChampManRebornContextFactory : IDesignTimeDbContextFactory<ChampManRebornContext>
{
    public ChampManRebornContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChampManRebornContext>();
        optionsBuilder.UseSqlServer("Your-Connection-String");

        return new ChampManRebornContext(optionsBuilder.Options);
    }
}