namespace ChampManReborn.Domain.Entities;

public class Team
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Stadium { get; set; }
    public List<Player> Players { get; set; } = [];
}