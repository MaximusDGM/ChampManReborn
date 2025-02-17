namespace ChampManReborn.Domain.Entities;

public abstract class League
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Team> Teams { get; set; } = [];
}