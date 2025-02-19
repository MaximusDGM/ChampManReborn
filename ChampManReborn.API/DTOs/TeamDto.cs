namespace ChampManReborn.API.DTOs;

public class TeamDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Stadium { get; set; }
}

public class CreateTeamDto
{
    public string Name { get; set; } = string.Empty;
    public string? Stadium { get; set; }
}