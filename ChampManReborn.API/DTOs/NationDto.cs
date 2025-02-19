namespace ChampManReborn.API.DTOs;

public class NationDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Continent { get; set; }
    public short Reputation { get; set; }
}

public class CreateNationDto
{
    public string Name { get; set; } = string.Empty;
    public int Continent { get; set; }
    public short Reputation { get; set; }
}