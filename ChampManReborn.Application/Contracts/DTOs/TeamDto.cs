namespace ChampManReborn.Application.Contracts.DTOs;

public class TeamDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Stadium { get; set; }
}

public class CreateTeamDto
{
    public required string Name { get; set; }
    public required string Stadium { get; set; }
}