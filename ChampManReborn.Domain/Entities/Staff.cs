namespace ChampManReborn.Domain.Entities;

public class Staff : Person
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? CommonName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int? YearOfBirth { get; set; }
    public Nation? Nation { get; set; }
    public Nation? SecondNation { get; set; }
    public byte InternationalApps { get; set; }
    public byte InternationalGoals { get; set; }
    public Team? NationContracted { get; set; }
    public DateTime? DateJoinedNation { get; set; }
    public DateTime? ContractExpiresNation { get; set; }
    public Team? ClubContracted { get; set; }
    public DateTime? DateJoinedClub { get; set; }
    public DateTime? ContractExpiresClub { get; set; }
    public decimal EstimatedWage { get; set; }
    public int EstimatedValue { get; set; }
    public int Adaptability { get; set; }
    public int Ambition { get; set; }
    public int Determination { get; set; }
    public int Loyalty { get; set; }
    public int Pressure { get; set; }
    public int Professionalism { get; set; }
    public int Sportsmanship { get; set; }
    public int Temperament { get; set; }
    public int ClubValuation { get; set; }
    public Player? PlayerData { get; set; }
}