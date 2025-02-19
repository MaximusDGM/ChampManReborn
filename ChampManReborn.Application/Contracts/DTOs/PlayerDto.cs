namespace ChampManReborn.Application.Contracts.DTOs;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public Guid TeamId { get; set; }
    public string? Position { get; set; }
    public int Skill { get; set; }
    public int Stamina { get; set; }
    public int CurrentAbility { get; set; }
    public int PotentialAbility { get; set; }
    public short HomeReputation { get; set; }
    public short CurrentReputation { get; set; }
    public short WorldReputation { get; set; }
}

public class CreatePlayerDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
    public Guid TeamId { get; set; }
    public string? Position { get; set; }
    public int Skill { get; set; }
    public int Stamina { get; set; }
    public int CurrentAbility { get; set; }
    public int PotentialAbility { get; set; }
}