namespace ChampManReborn.Application.Contracts.DTOs;

public class StaffDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? CommonName { get; set; }
    public int? Age { get; set; }
}

public class CreateStaffDto
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? CommonName { get; set; }
}