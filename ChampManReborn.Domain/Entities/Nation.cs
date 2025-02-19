namespace ChampManReborn.Domain.Entities;

public class Nation
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? GenderName { get; set; }
    public string? ShortName { get; set; }
    public string? GenderNameShort { get; set; }
    public string? NameThreeLetter { get; set; }
    public string? NameNationality { get; set; }
    public int Continent { get; set; }
    public string? Region { get; set; }
    public string? ActualRegion { get; set; }
    public string? FirstLanguage { get; set; }
    public string? SecondLanguage { get; set; }
    public string? ThirdLanguage { get; set; }
    public int? CapitalCity { get; set; }
    public string? StateOfDevelopment { get; set; }
    public string? GroupMembership { get; set; }
    public int? NationalStadium { get; set; }
    public string? GameImportance { get; set; }
    public string? LeagueStandard { get; set; }
    public short NumberClubs { get; set; }
    public int NumberStaff { get; set; }
    public short SeasonUpdateDay { get; set; }
    public short Reputation { get; set; }
    public ColorScheme TeamColor { get; set; } = new();
    public bool LeagueSelected { get; set; }
    public int ShortlistOffset { get; set; }
    public int GamesPlayed { get; set; }

    public class ColorScheme
    {
        public int ForegroundColor { get; set; }
        public int BackgroundColor { get; set; }
    }
}