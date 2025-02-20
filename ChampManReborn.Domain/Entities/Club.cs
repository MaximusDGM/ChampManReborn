namespace ChampManReborn.Domain.Entities;

public class Club
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Stadium { get; set; }
    public bool OwnStadium { get; set; }
    public string? ReserveStadium { get; set; }
    public int Attendance { get; set; }
    public int MinAttendance { get; set; }
    public int MaxAttendance { get; set; }
    public bool Training { get; set; }
    public short Reputation { get; set; }
    public Guid? ChairmanId { get; set; }
    public Staff? Chairman { get; set; }
    public List<Staff> Directors { get; set; } = [];
    public Guid? ManagerId { get; set; }
    public Staff? Manager { get; set; }
    public Guid? AssistantManagerId { get; set; }
    public Staff? AssistantManager { get; set; }
    public List<Staff> Squad { get; set; } = [];
    public List<Staff> Coaches { get; set; } = [];
    public List<Staff> Scouts { get; set; } = [];
    public List<Staff> Physios { get; set; } = [];
    public string? ShortName { get; set; }
    public Nation? Nation { get; set; }
    public List<Staff> FavouriteStaff { get; set; } = [];
    public List<Staff> DislikedStaff { get; set; } = [];
    public List<Club> RivalClubs { get; set; } = [];
}