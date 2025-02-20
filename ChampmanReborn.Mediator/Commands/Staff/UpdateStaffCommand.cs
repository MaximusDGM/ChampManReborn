using MediatR;

namespace ChampManReborn.Mediator.Commands.Staff;

public class UpdateStaffCommand(Guid id, string firstName, string secondName, string commonName)
    : IRequest
{
    public Guid Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string SecondName { get; set; } = secondName;
    public string CommonName { get; set; } = commonName;
}