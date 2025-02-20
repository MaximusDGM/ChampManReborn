using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class CreateStaffCommand(string firstName, string secondName, string commonName) : IRequest<Guid>
{
    public string FirstName { get; set; } = firstName;
    public string SecondName { get; set; } = secondName;
    public string CommonName { get; set; } = commonName;
}