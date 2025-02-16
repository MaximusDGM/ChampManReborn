namespace ChampManReborn.Domain.Entities;

public class Player : Person
{
    public required string Position { get; set; }
    public int Skill { get; set; }
    public int Stamina { get; set; }
}
