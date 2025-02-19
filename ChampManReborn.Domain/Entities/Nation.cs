namespace ChampManReborn.Domain.Entities;

public class Nation
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? NameThreeLetter { get; set; }
    public string? NameNationality { get; set; }
    public int Continent { get; set; }
    public int? CapitalCity { get; set; }
    public short NumberClubs { get; set; }
    public int NumberStaff { get; set; }
    public short Reputation { get; set; }
}