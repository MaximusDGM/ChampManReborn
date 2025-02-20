namespace ChampManReborn.Domain.Entities;

public class League
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<Club> Teams { get; set; } = [];
}