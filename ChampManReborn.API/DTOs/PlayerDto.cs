namespace ChampManReborn.API.DTOs;

public class PlayerDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public Guid TeamId { get; set; }
}

public class CreatePlayerDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
}