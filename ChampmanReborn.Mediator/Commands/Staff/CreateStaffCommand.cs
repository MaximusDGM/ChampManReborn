using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class CreateStaffCommand(string firstName, string lastName, string commonName) : IRequest<Guid>
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string CommonName { get; set; } = commonName;
}