namespace ChampManReborn.Application.Contracts.DTOs;

public class ClubDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Stadium { get; set; }
}

public class CreateClubDto
{
    public required string Name { get; set; }
    public required string Stadium { get; set; }
}