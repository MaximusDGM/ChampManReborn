using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class UpdateStaffCommand(Guid id, string firstName, string lastName, string commonName)
    : IRequest
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string CommonName { get; set; } = commonName;
}