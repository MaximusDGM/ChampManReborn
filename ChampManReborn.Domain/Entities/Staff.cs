namespace ChampManReborn.Domain.Entities;

public class Staff : Person
{
    public Nation? Nation { get; set; }
    public Nation? SecondNation { get; set; }
    public int Adaptability { get; set; }
    public int Ambition { get; set; }
    public int Determination { get; set; }
    public int Loyalty { get; set; }
    public int Pressure { get; set; }
    public int Professionalism { get; set; }
    public int Sportsmanship { get; set; }
    public int Temperament { get; set; }
    public Player? PlayerData { get; set; }
}